/**
 * Demonstration C program illustrating how to perform file I/O for vm assignment.
 *
 * Input file contains logical addresses
 * 
 * Backing Store represents the file being read from disk (the backing store.)
 *
 * We need to perform random input from the backing store using fseek() and fread()
 *
 * This program performs nothing of meaning, rather it is intended to illustrate the basics
 * of I/O for the vm assignment. Using this I/O, you will need to make the necessary adjustments
 * that implement the virtual memory manager.
 * 
 * Sources referenced for help/inspiration:
 * 
 * https://www.ibm.com/developerworks/aix/tutorials/au-memorymanager/
 * https://www.tutorialspoint.com/cprogramming/c_memory_management.htm
 * https://www.cprogramming.com/tutorial/virtual_memory_and_heaps.html
 * https://www.tutorialspoint.com/c_standard_library/string_h.htm
 * http://heather.cs.ucdavis.edu/~matloff/UnixAndC/CLanguage/BitOps.html
 * https://www.codingunit.com/printf-format-specifiers-format-conversions-and-formatted-output
 * https://www.tutorialspoint.com/c_standard_library/c_function_fseek.htm
 * http://www.c4learn.com/c-programming/c-bitwise-left-shift-operator/
 */

#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>

/*
• 2^8 entries in the page table 
• Page size of 2^8 bytes 
• 16 entries in the TLB 
• Frame size of 2^8 bytes 
• 256 frames 
• Physical memory of 65,536 bytes (256 frames × 256-byte frame size)
*/

// number of characters to read for each line from input file
#define BUFFER_SIZE 10

//2^8 page size in bytes
#define PAGESIZE 256

//16 entries in the TBL
#define ENTRIESINTLB 16

//2^8 bytes in frame size
#define FRAMESIZE 256

//256 frames
#define FRAMESTOTAL 256

// number of bytes to read (2^8)
#define CHUNK 256

FILE *address_file;
FILE *backing_store;

// how we store reads from input file
char address[BUFFER_SIZE];

int logical_address;

// the buffer containing reads from backing store
signed char buffer[CHUNK];

// the value of the byte (signed char) in memory
signed char value;

int pagesNums[PAGESIZE];
int pageFrames[PAGESIZE];
int tlbPageNum[ENTRIESINTLB];
int tlbFrameNum[ENTRIESINTLB];

//256x256 = 65,536
int physicalMemory[FRAMESTOTAL][FRAMESIZE];

int faults = 0;
int hits = 0;
int firstOpenFrame = 0;
int firstOpenPage = 0;
int tlbEntries = 0;

//had to create headers to prevent conflict with method types
void getPageData(int address);
void readFromTheStore(int pageNumber);
void placeInTLB(int pageNumber, int frameNumber);

int main(int argc, char *argv[])
{
    int i = 0;

    // perform basic error checking
    if (argc != 3)
    {
        fprintf(stderr, "Usage: ./vm [backing store] [input file]\n");
        return -1;
    }

    // open the file containing the backing store
    backing_store = fopen(argv[1], "rb");

    if (backing_store == NULL)
    {
        fprintf(stderr, "Error opening %s\n", argv[1]);
        return -1;
    }

    // open the file containing the logical addresses
    address_file = fopen(argv[2], "r");

    if (address_file == NULL)
    {
        fprintf(stderr, "Error opening %s\n", argv[2]);
        return -1;
    }

    int numTranslated = 0; //counter for addresses translated
    //read through the input file and output each logical address
    while (fgets(address, BUFFER_SIZE, address_file) != NULL)
    {
        logical_address = atoi(address);

        // first seek to byte CHUNK in the backing store
        // SEEK_SET in fseek() seeks from the beginning of the file
        if (fseek(backing_store, CHUNK * i, SEEK_SET) != 0)
        {
            fprintf(stderr, "Error seeking in backing store\n");
            return -1;
        }

        // now read CHUNK bytes from the backing store to the buffer
        if (fread(buffer, sizeof(signed char), CHUNK, backing_store) == 0)
        {
            fprintf(stderr, "Error reading from backing store\n");
            return -1;
        }

        // arbitrarily retrieve the 50th byte from the buffer
        //value = buffer[50];

        //printf("%d \t %d\n",logical_address, value);

        // just so we seek to 10 different spots in the file
        //i = (i + 1) % 10;

        getPageData(logical_address);
        numTranslated++;
    }

    printf("Number translated = %d\n", numTranslated);
    double faultRate = faults / (double)numTranslated;
    double hitRate = hits / (double)numTranslated;

    printf("Page faults: %d\n", faults);
    printf("Page fault fate: %.5f\n", faultRate);
    printf("TLB hits: %d\n", hits);
    printf("TLB hit rate: %.5f\n", hitRate);

    fclose(address_file);
    fclose(backing_store);

    return 0;
}

// function is given the logical address and obtains the physical address/value stored at given address
void getPageData(int logical_address)
{

    //Obtain the page number
    int pageNumber = ((logical_address & 0xFFFF) >> 8); //use hex mask for address
    int offset = (logical_address & 0xFF);              //use mask for offset

    //first try to get page from TLB
    int frameNumber = -1;
    int i;
    for (i = 0; i < ENTRIESINTLB; i++)
    {
        if (tlbPageNum[i] == pageNumber)
        {                                 //TLB page num is equal to the pageNumber
            frameNumber = tlbFrameNum[i]; //set frameNum to that TLB index
            hits++;                       //add a tick to our hit counter
        }
    }

    //not found
    if (frameNumber == -1)
    {
        int i; //walk the contents of the page table
        for (i = 0; i < firstOpenPage; i++)
        {
            if (pagesNums[i] == pageNumber)
            {
                frameNumber = pageFrames[i]; //take frameNumber from pageFrame array
            }
        }
        if (frameNumber == -1)
        {                                     //still not found
            readFromTheStore(pageNumber);     //page fault, call readFromTheStore
            faults++;                         //increment page fault counter
            frameNumber = firstOpenFrame - 1; //set frameNumber to the current firstOpenFrame index
        }
    }

    placeInTLB(pageNumber, frameNumber); 
    value = physicalMemory[frameNumber][offset]; // frame number and offset used to get the signed value stored at that address
    printf("Frame number: %d\n", frameNumber);
    printf("Offset: %d\n", offset);
    //output the data we need; << is a bitwise left shift
    printf("Virtual address: %d Physical address: %d Value: %d\n", logical_address, (frameNumber << 8) | offset, value);
}

//function to insert a page and frame number in the TLB via FIFO
void placeInTLB(int pageNumber, int frameNumber)
{

    int i;
    for (i = 0; i < tlbEntries; i++)
    {
        if (tlbPageNum[i] == pageNumber)
        {
            break; //TLB already contains; break
        }
    }

    //if number of entries is equal to the index
    if (i == tlbEntries)
    {
        if (tlbEntries < ENTRIESINTLB)
        {                                        //Room left
            tlbPageNum[tlbEntries] = pageNumber; //insert on the end
            tlbFrameNum[tlbEntries] = frameNumber;
        }
        else
        { //shift everything over
            for (i = 0; i < ENTRIESINTLB - 1; i++)
            {
                tlbPageNum[i] = tlbPageNum[i + 1];
                tlbFrameNum[i] = tlbFrameNum[i + 1];
            }
            tlbPageNum[tlbEntries - 1] = pageNumber; //insert the page and frame on the end
            tlbFrameNum[tlbEntries - 1] = frameNumber;
        }
    }

    //if index is not equal to the number of tblEntries
    else
    {
        for (i = i; i < tlbEntries - 1; i++)
        {                                      // iterate through the entries
            tlbPageNum[i] = tlbPageNum[i + 1]; //move everything over in the arrays
            tlbFrameNum[i] = tlbFrameNum[i + 1];
        }
        if (tlbEntries < ENTRIESINTLB)
        { //room left, place on the end
            tlbPageNum[tlbEntries] = pageNumber;
            tlbFrameNum[tlbEntries] = frameNumber;
        }
        else
        { //page and fram on entries
            tlbPageNum[tlbEntries - 1] = pageNumber;
            tlbFrameNum[tlbEntries - 1] = frameNumber;
        }
    }
    if (tlbEntries < ENTRIESINTLB)
    { //if still room left then increment
        tlbEntries++;
    }
}

// function to read from the backing store and bring the frame into physical memory and the page table
void readFromTheStore(int pageNumber)
{
    //fseek to CHUNK in BACKING_STORE
    if (fseek(backing_store, pageNumber * CHUNK, SEEK_SET) != 0)
    { //SEEK_SET from fseek; the beginning of the file
        fprintf(stderr, "Error seeking in BACKING_STORE\n");
    }

    //now read CHUNK bytes from the backing store to the buffer
    if (fread(buffer, sizeof(signed char), CHUNK, backing_store) == 0)
    {
        fprintf(stderr, "Error reading from BACKING_STORE\n");
    }

    int i;
    for (i = 0; i < CHUNK; i++)
    {
        physicalMemory[firstOpenFrame][i] = buffer[i]; //load bits to the first available frame in physicalMemory
    }

    //then load the frame number into the page table
    pagesNums[firstOpenPage] = pageNumber;
    pageFrames[firstOpenPage] = firstOpenFrame;

    //increment the counters
    firstOpenFrame++;
    firstOpenPage++;
}

/**
		 * Searches for page pageNumber in the page frame list
		 * @return true if pageNumber was found
		 * @return false if pageNumber was not found
		 */
/*boolean search(int pageNumber) {
			boolean returnVal = false;

			for (int i = 0; i < pageFrameList.size(); i++) {
				if (pageNumber == pageFrameList.get(i)) {
					returnVal = true;
					break;
				}
			}
			return returnVal;
		}*/
