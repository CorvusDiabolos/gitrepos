using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Configuration;
using System.Globalization;
using ExcelInterop = Microsoft.Office.Interop.Excel;
using System.Collections;

namespace Pathology_Report_Query___BETA
{
    public partial class Dashboard : Form
    {
        int originalExStyle = -1;
        bool enableFormLevelDoubleBuffering = true;
        int panelWidth;
        bool hidden;
        private bool mouseDown;
        private Point lastLocation;
        readonly string dateHint = "mm/dd/yyyy";
        readonly string keywordHint = "diagnosis keyword here";
        bool includeAddenda = false;
        SqlConnection connection;
        readonly string connectionString;
        private readonly Stopwatch _stopwatch = new Stopwatch();
        string startDate;
        string endDate;
        string prefixSelection;
        Dictionary<string, string> prefixDxCodeDict = new Dictionary<string, string>();
        Dictionary<string, string> addendaCodeDict = new Dictionary<string, string>();
        DataTable queryDataTable = new DataTable();
        SqlDataAdapter adapter;
        bool cancelled = false;
        bool phiMode = true;
        DateTime startDateTime;
        DateTime endDateTime;

        public Dashboard()
        {
            connectionString = ConfigurationManager.ConnectionStrings["Pathology_Report_Query___BETA.Properties.Settings.ConnectionString"].ConnectionString;
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            panelWidth = slidePanel.Width;
            hidden = true;
            slidePanel.Width = 0;
            startDatePicker.MaxDate = DateTime.Today;
            endDatePicker.MaxDate = DateTime.Today;
            prefixComboBox.SelectedIndex = prefixComboBox.Items.IndexOf("SP");

            prefixDxCodeDict.Add("HP", "8070145");
            prefixDxCodeDict.Add("SP", "8070050");
            prefixDxCodeDict.Add("OC", "8070050");
            prefixDxCodeDict.Add("RO", "8070050");
            prefixDxCodeDict.Add("MO", "8070050");
            prefixDxCodeDict.Add("FA", "2000492");
            prefixDxCodeDict.Add("BM", "8410030");
            prefixDxCodeDict.Add("CG", "2000527");
            prefixDxCodeDict.Add("CN", "2000591");
            prefixDxCodeDict.Add("AU", "8080070");
            prefixDxCodeDict.Add("BT", "8100530");
            prefixDxCodeDict.Add("TX", "2001869");
            prefixDxCodeDict.Add("UF", "8100640");
            prefixDxCodeDict.Add("CB", "2008961");
            prefixDxCodeDict.Add("NG", "8209835");
            prefixDxCodeDict.Add("GA", "2000502");
            prefixDxCodeDict.Add("GG", "8100160");
            prefixDxCodeDict.Add("SR", "2010663");
            prefixDxCodeDict.Add("TH", "2000537");
            prefixDxCodeDict.Add("TR", "8100212");
            //prefixDxCodeDict.Add("IP", "2003356"); //removed IP as very few exist and system is still in proof-of-concept stage
            prefixDxCodeDict.Add("NP", "2000575");
            prefixDxCodeDict.Add("GH", "2000480");
            prefixDxCodeDict.Add("GR", "2000513");
            prefixDxCodeDict.Add("GT", "2000549");
            prefixDxCodeDict.Add("PF", "2002456");
            prefixDxCodeDict.Add("RX", "8070050");

            addendaCodeDict.Add("HP", "2007696");
            addendaCodeDict.Add("SP", "8070090");
            addendaCodeDict.Add("OC", "8070090");
            addendaCodeDict.Add("RO", "8070090");
            addendaCodeDict.Add("MO", "8070090");
            addendaCodeDict.Add("FA", "2000631");
            addendaCodeDict.Add("BM", "2007696");
            addendaCodeDict.Add("CG", "2000631");
            addendaCodeDict.Add("CN", "2000631");
            addendaCodeDict.Add("AU", "8070090");
            addendaCodeDict.Add("BT", "2000631");
            addendaCodeDict.Add("TX", "2007696");
            addendaCodeDict.Add("UF", "2000631");
            addendaCodeDict.Add("CB", "2007696");
            addendaCodeDict.Add("NG", "2000631");
            addendaCodeDict.Add("GA", "2000631");
            addendaCodeDict.Add("GG", "2000631");
            addendaCodeDict.Add("SR", "2000631");
            addendaCodeDict.Add("TH", "2000631");
            addendaCodeDict.Add("TR", "2000631");
            //addendaCodeDict.Add("IP", "2007696");
            addendaCodeDict.Add("NP", "2000631");
            addendaCodeDict.Add("GH", "2000631");
            addendaCodeDict.Add("GR", "2000631");
            addendaCodeDict.Add("GT", "2000631");
            addendaCodeDict.Add("PF", "2000631");
            addendaCodeDict.Add("RX", "8070090");
        }


        private void panelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void panelHeader_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void panelHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point((this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                this.Update();
            }
        }


        protected override void WndProc(ref Message m) //https://stackoverflow.com/questions/31199437/borderless-and-resizable-form-c
        {
            const int RESIZE_HANDLE_SIZE = 10;

            switch (m.Msg)
            {
                case 0x0084/*NCHITTEST*/ :
                    base.WndProc(ref m);

                    if ((int)m.Result == 0x01/*HTCLIENT*/)
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32());
                        Point clientPoint = this.PointToClient(screenPoint);
                        if (clientPoint.Y <= RESIZE_HANDLE_SIZE)
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)13/*HTTOPLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)12/*HTTOP*/ ;
                            else
                                m.Result = (IntPtr)14/*HTTOPRIGHT*/ ;
                        }
                        else if (clientPoint.Y <= (Size.Height - RESIZE_HANDLE_SIZE))
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)10/*HTLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)2/*HTCAPTION*/ ;
                            else
                                m.Result = (IntPtr)11/*HTRIGHT*/ ;
                        }
                        else
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)16/*HTBOTTOMLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)15/*HTBOTTOM*/ ;
                            else
                                m.Result = (IntPtr)17/*HTBOTTOMRIGHT*/ ;
                        }
                    }
                    return;
            }
            base.WndProc(ref m);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                if (originalExStyle == -1) //https://web.archive.org/web/20160405111506/http://www.angryhacker.com/blog/archive/2010/07/21/how-to-get-rid-of-flicker-on-windows-forms-applications.aspx
                {
                    originalExStyle = base.CreateParams.ExStyle;
                }

                CreateParams cp = base.CreateParams;
                cp.Style |= 0x20000; // <--- use 0x20000
                if (enableFormLevelDoubleBuffering)
                {
                    cp.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED //https://stackoverflow.com/questions/3286373/flickering-in-a-windows-forms-app
                }
                else
                {
                    cp.ExStyle = originalExStyle;
                }


                return cp;
            }
        }

        private void TurnOffFormLevelDoubleBuffering()
        {
            enableFormLevelDoubleBuffering = false;
            //this.MaximizeBox = true; //this isn't needed in a borderless form, but needed for proper min/max/close functionality in a bordered form
        }

        private void Dashboard_Shown(object sender, EventArgs e)
        {
            TurnOffFormLevelDoubleBuffering();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MaximizeButton_Click(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Dashboard_Resize(object sender, EventArgs e)
        {
            resultsGrid.Refresh();
        }

        private void slideButton_Click(object sender, EventArgs e)
        {
            slideTimer.Start();
            endDatePicker.Visible = false;
            startDatePicker.Visible = false;
        }

        private void slideTimer_Tick(object sender, EventArgs e)
        {
            if (hidden)
            {
                slidePanel.Width = slidePanel.Width + 40;
                if (slidePanel.Width >= panelWidth)
                {
                    slideTimer.Stop();
                    hidden = false;
                    slideButton.BackgroundImage.RotateFlip(RotateFlipType.Rotate90FlipX);
                    this.Refresh();
                }
            }
            else
            {
                slidePanel.Width = slidePanel.Width - 40;
                if (slidePanel.Width <= 0)
                {
                    slideTimer.Stop();
                    hidden = true;
                    slideButton.BackgroundImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    this.Refresh();
                }
            }

        }

        private void panelHeader_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MaximizeButton_Click(sender, e);
        }

        private void startDateTextBox_Enter(object sender, EventArgs e)
        {
            endDatePicker.Visible = false;
            startDatePicker.Visible = false;

            if (startDateTextBox.Text == dateHint)
            {
                startDateTextBox.Text = "";
                startDateTextBox.ForeColor = Color.White;
            }
        }

        private void startDateTextBox_Leave(object sender, EventArgs e)
        {
            if (startDateTextBox.Text == "")
            {
                startDateTextBox.Text = dateHint;
                startDateTextBox.ForeColor = Color.DimGray;
            }
        }

        private void endDateTextBox_Enter(object sender, EventArgs e)
        {
            endDatePicker.Visible = false;
            startDatePicker.Visible = false;

            if (endDateTextBox.Text == dateHint)
            {
                endDateTextBox.Text = "";
                endDateTextBox.ForeColor = Color.White;
            }
        }

        private void endDateTextBox_Leave(object sender, EventArgs e)
        {
            if (endDateTextBox.Text == "")
            {
                endDateTextBox.Text = dateHint;
                endDateTextBox.ForeColor = Color.DimGray;
            }
        }

        private void keywordTextBox_Enter(object sender, EventArgs e)
        {
            if (keywordTextBox.Text == keywordHint)
            {
                keywordTextBox.Text = "";
                keywordTextBox.ForeColor = Color.White;
            }
        }

        private void keywordTextBox_Leave(object sender, EventArgs e)
        {
            if (keywordTextBox.Text == "")
            {
                keywordTextBox.Text = keywordHint;
                keywordTextBox.ForeColor = Color.DimGray;
            }
        }

        private void addendaButton_Click(object sender, EventArgs e)
        {
            if (!includeAddenda)
            {
                addendaButton.BackgroundImage = Properties.Resources.icons8_checked_checkbox_32;
                includeAddenda = true;
            }
            else
            {
                addendaButton.BackgroundImage = Properties.Resources.icons8_unchecked_checkbox_32;
                includeAddenda = false;
            }
        }

        private void dateFromButton_Click(object sender, EventArgs e)
        { //https://www.codeproject.com/Questions/143036/Datetime-picker-as-a-icon-in-C-Windows-application
            startDatePicker.Visible = !startDatePicker.Visible;
            startDatePicker.BringToFront();
            endDatePicker.Visible = false;
        }

        private void startDatePicker_DateSelected(object sender, DateRangeEventArgs e)
        {
            startDateTextBox.Text = ((MonthCalendar)sender).SelectionStart.ToShortDateString();
            startDateTextBox.ForeColor = Color.White;
            startDatePicker.Visible = false;
        }

        private void DateToButton_Click(object sender, EventArgs e)
        {
            endDatePicker.Visible = !endDatePicker.Visible;
            endDatePicker.BringToFront();
            startDatePicker.Visible = false;
        }

        private void endDatePicker_DateSelected(object sender, DateRangeEventArgs e)
        {
            endDateTextBox.Text = ((MonthCalendar)sender).SelectionStart.ToShortDateString();
            endDateTextBox.ForeColor = Color.White;
            endDatePicker.Visible = false;
        }

        private void searchStopButton_Click(object sender, EventArgs e)
        {
            endDatePicker.Visible = false;
            startDatePicker.Visible = false;

            if (searchBackgroundWorker.IsBusy)
            {
                cancelled = true;
                searchBackgroundWorker.CancelAsync();
                adapter.SelectCommand.Cancel();
            }
            else if (safeText() && SafeDateRange())
            {
                queryDataTable = new DataTable();
                resultsGrid.Visible = false;
                rowCount.Visible = false;
                resultsGrid.DataSource = null;
                stopWatchText.Text = "00:00:00";
                rowCount.Text = "Rows: 0";
                searchTimer.Start();
                loadingBar.Visible = true;
                stopWatchText.Visible = true;
                searchStopButton.BackgroundImage = Properties.Resources.icons8_stop_sign_32;
                refreshButton.Visible = false;
                excelGlowButton.Visible = false;
                searchBackgroundWorker.RunWorkerAsync();
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            keywordTextBox.ResetText();
            keywordTextBox_Leave(sender, e);
            prefixComboBox.SelectedIndex = prefixComboBox.Items.IndexOf("SP");
            startDateTextBox.ResetText();
            startDateTextBox_Leave(sender, e);
            endDateTextBox.ResetText();
            endDateTextBox_Leave(sender, e);
            andKeywordBox.ResetText();
            orKeywordBox.ResetText();
            notKeywordBox.ResetText();
            queryDataTable = new DataTable();
            resultsGrid.Visible = false;
            resultsGrid.DataSource = null;
            loadingBar.Visible = false;
            addendaButton.BackgroundImage = Properties.Resources.icons8_unchecked_checkbox_32;
            includeAddenda = false;
            rowCount.Visible = false;
            rowCount.Text = "Rows: 0";
            stopWatchText.Visible = false;
            stopWatchText.Text = "00:00:00";
            excelGlowButton.Visible = false;
            endDatePicker.Visible = false;
            startDatePicker.Visible = false;
        }

        private void resultsGrid_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            rowCount.Text = String.Format("Rows: {0:#,#}", resultsGrid.RowCount.ToString("#,#", CultureInfo.InvariantCulture));
        }

        private bool safeText()
        {
            string keyword = keywordTextBox.Text.ToString().ToLower().Trim();
            string andKeyword = andKeywordBox.Text.ToString().ToLower().Trim();
            string orKeyword = orKeywordBox.Text.ToString().ToLower().Trim();
            string notKeyword = notKeywordBox.Text.ToString().ToLower().Trim();

            List<string> badText = new List<string>() { ";", "--", "/*", "*/", "\\*", "/\\*", "xp_", "\""};

            if (badText.Any(keyword.Contains) || badText.Any(andKeyword.Contains) || badText.Any(orKeyword.Contains) || badText.Any(notKeyword.Contains))
            {
                MessageBox.Show("One ore more of your text fields contains a forbidden character.", "DENIED!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            return true;
        }

        private bool SafeDateRange()
        {
            try
            {
                string startDateText = startDateTextBox.Text.ToString().Replace(".", "/").Replace("-", "/").Trim();
                string endDateText = endDateTextBox.Text.ToString().Replace(".", "/").Replace("-", "/").Trim();
                if (startDateTextBox.Text == dateHint && endDateTextBox.Text == dateHint)
                {
                    startDateTime = DateTime.Today.AddYears(-1);
                    endDateTime = DateTime.Today;
                    startDateTextBox.Text = startDateTime.ToString("MM/dd/yyyy");
                    endDateTextBox.Text = endDateTime.ToString("MM/dd/yyyy");
                    startDateTextBox.ForeColor = Color.White;
                    endDateTextBox.ForeColor = Color.White;
                }
                else if ((startDateTextBox.Text == dateHint && endDateTextBox.Text != dateHint) || (startDateTextBox.Text != dateHint && endDateTextBox.Text == dateHint))
                {
                    MessageBox.Show("Need both start and stop dates.  Use format " + dateHint, "WAIT!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
                else
                {
                    startDateTime = DateTime.Parse(startDateText);
                    endDateTime = DateTime.Parse(endDateText);
                }

                startDate = startDateTime.ToString("yyyy-MM-dd");
                endDate = endDateTime.ToString("yyyy-MM-dd");
            }
            catch
            {
                MessageBox.Show("Invalid date or date format.  Use format " + dateHint, "WAIT!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            int days = (endDateTime - startDateTime).Days;

            if (days > 366)
            {
                DialogResult response;
                response = MessageBox.Show("Searches spanning over a year may take a few minutes to process and will time-out after 10 minutes.\n\nContinue?", "ALERT!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (response == DialogResult.Yes)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (days < 0)
            {
                MessageBox.Show("End Date must come after Start Date", "WAIT!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            return true;

        }
        private String SQLQueryBuilder()
        {
            string sqlQuery;
            DateTime hpaCreated = DateTime.Parse("11/10/2012"); 
            string hemeCases = "HP, BM, TX, CB";
            string dxCode = prefixDxCodeDict[prefixSelection];
            string addendaCode = addendaCodeDict[prefixSelection]; //include date check for older cases; don't forget ' !!!!!
            string addendaBracket1, addendaBracket2;
            string keyword = keywordTextBox.Text.ToString().ToLower().Replace(keywordHint, "").Replace("*", "%").Replace("'", "''").Trim();
            string andKeyword = andKeywordBox.Text.ToString().ToLower().Replace("*", "%").Replace("'", "''").Trim();
            string orKeyword = orKeywordBox.Text.ToString().ToLower().Replace("*", "%").Replace("'", "''").Trim();
            string notKeyword = notKeywordBox.Text.ToString().ToLower().Replace("*", "%").Replace("'", "''").Trim();
            string reportAnd = "";
            string addendaAnd = "";
            string reportOr = "";
            string addendaOr = "";
            string reportNot = "";
            string addendaNot = "";
            string oldHemeAddenda = "";

            if (!String.IsNullOrEmpty(andKeyword))
            {
                reportAnd = "AND res.result LIKE @andWord";
                addendaAnd = "AND spa.result LIKE @andWord";
            }
            if (!String.IsNullOrEmpty(orKeyword))
            {
                reportOr = "OR res.RESULT LIKE @orWord";
                addendaOr = "OR spa.RESULT LIKE @orWord";
            }
            if (!String.IsNullOrEmpty(notKeyword))
            {
                reportNot = "AND res.RESULT NOT LIKE @notWord";
                addendaNot = "AND spa.RESULT NOT LIKE @notWord";
            }

            if (includeAddenda)
            {
                if (startDateTime.Date < hpaCreated.Date && hemeCases.Contains(prefixSelection))
                {
                    oldHemeAddenda = "OR spa.RESULT_TEST_NUM = '8070090'";
                }
                addendaBracket1 = "";
                addendaBracket2 = "";
            } else
            {
                addendaBracket1 = "/*";
                addendaBracket2 = "*/";
            }

            if (phiMode)
            {
                sqlQuery = String.Format("declare @startDate date = '{0}' declare @endDate date = '{1}' declare @currentDate datetime = GETDATE() declare @dxCode char(7) = '{2}' declare @prefixSelection char(3) = '{3}%' declare @keyword varchar(max) = '%{4}%' declare @andWord varchar(max) = '%{5}%' declare @orWord varchar(max) = '%{6}%' declare @notWord varchar(max) = '%{7}%' declare @addendaCode varchar(max) = '{8}' (SELECT IIF(res.ECR_STATUS LIKE 'n', 'X', '') AS [ECR'd],res.RESULT_TEST_MNEMONIC AS [RPT. SEC.], his.ACCESSION as [CASE #], replace(replace(res.RESULT,char(13),' '),char(10),' ') as [RESULT], his.PREV_VER_WHEN AS [VERIFIED], emp.LAST_NAME + ', ' + emp.FIRST_NAME AS [PATHOLOGIST], pat.SEX, IIF(pat.BIRTH_WHEN <= '1900-01-01','U',convert(char(3),FLOOR(DATEDIFF(day,pat.BIRTH_WHEN,his.PREV_VER_WHEN)/365.242199))) as [AGE/VERIFIED], IIF(pat.BIRTH_WHEN <= '1900-01-01','U',convert(char(3),FLOOR(DATEDIFF(day,pat.BIRTH_WHEN,@currentDate)/365.242199))) as [AGE/TODAY], pat.REQ_NUM as [MRN] FROM server.schema.historicResultTable AS his INNER JOIN server.schema.resultTable AS res ON (his.ACCESSION = res.ACCESSION AND his.RESULT_TEST_NUM = res.RESULT_TEST_NUM) INNER JOIN server.schema.employeeTable emp ON res.VER_BY = emp.EMPLOYEE_ID INNER JOIN server.schema.patientTable AS pat ON res.ENCOUNTER = pat.ENCOUNTER INNER JOIN server.schema.clientTable as cli ON res.CLIENT_ID = cli.CLIENT_ID WHERE his.PREV_VER_WHEN >= @startDate and his.PREV_VER_WHEN <= dateadd(d,1,@endDate) AND his.PREV_RESULT_STAT not like 'c' AND (res.RESULT_TEST_NUM = @dxCode) AND his.ACCESSION LIKE @prefixSelection AND (res.RESULT LIKE @keyword {9} {10} {11}) AND cli.FAKE_CLIENT LIKE 'n' AND res.ECR_STATUS like 'n' UNION SELECT IIF(res.ECR_STATUS LIKE 'n', 'X', '') AS [ECR'd], res.RESULT_TEST_MNEMONIC AS [RPT. SEC.], res.ACCESSION as [CASE #], replace(replace(res.RESULT,char(13),' '),char(10),' ') as [RESULT], res.VER_WHEN AS [VERIFIED], emp.LAST_NAME + ', ' + emp.FIRST_NAME AS [PATHOLOGIST], pat.SEX, IIF(pat.BIRTH_WHEN <= '1900-01-01','U',convert(char(3),FLOOR(DATEDIFF(day,pat.BIRTH_WHEN,res.VER_WHEN)/365.242199))) AS [AGE/VERIFIED], IIF(pat.BIRTH_WHEN <= '1900-01-01','U',convert(char(3),FLOOR(DATEDIFF(day,pat.BIRTH_WHEN,@currentDate)/365.242199))) AS [AGE/TODAY], pat.REQ_NUM AS [MRN] FROM server.schema.resultTable AS res INNER JOIN server.schema.employeeTable emp ON res.VER_BY = emp.EMPLOYEE_ID INNER JOIN server.schema.patientTable AS pat ON res.ENCOUNTER = pat.ENCOUNTER INNER JOIN server.schema.clientTable as cli ON res.CLIENT_ID = cli.CLIENT_ID WHERE res.VER_WHEN >= @startDate AND res.VER_WHEN <= dateadd(d, 1, @endDate) AND (res.RESULT_TEST_NUM = @dxCode) AND res.ACCESSION LIKE @prefixSelection AND (res.RESULT LIKE @keyword {9} {10} {11}) AND res.ECR_STATUS NOT LIKE 'n' AND cli.FAKE_CLIENT LIKE 'n' {12} UNION SELECT IIF(spa.ECR_STATUS LIKE 'n', 'X', '') AS[ECR'd], spa.RESULT_TEST_MNEMONIC AS [RPT. SEC.], spa.ACCESSION AS [CASE #], replace(replace(spa.RESULT,char(13),' '),char(10),' ') as [RESULT], res.VER_WHEN AS [VERIFIED], emp.LAST_NAME + ', ' + emp.FIRST_NAME AS [PATHOLOGIST], pat.SEX, IIF(pat.BIRTH_WHEN <= '1900-01-01', 'U', convert(char(3), FLOOR(DATEDIFF(day, pat.BIRTH_WHEN, res.VER_WHEN) / 365.242199))) as [AGE / VERIFIED], IIF(pat.BIRTH_WHEN <= '1900-01-01', 'U', convert(char(3), FLOOR(DATEDIFF(day, pat.BIRTH_WHEN, @currentDate) / 365.242199))) as [AGE / TODAY], pat.REQ_NUM as [MRN] FROM server.schema.resultTable AS spa INNER JOIN server.schema.resultTable AS res ON spa.ACCESSION = res.ACCESSION INNER JOIN server.schema.employeeTable AS emp ON spa.VER_BY = emp.EMPLOYEE_ID INNER JOIN server.schema.patientTable AS pat ON spa.ENCOUNTER = pat.ENCOUNTER INNER JOIN server.schema.clientTable as cli ON spa.CLIENT_ID = cli.CLIENT_ID  WHERE res.VER_WHEN >= @startDate and res.VER_WHEN <= dateadd(d, 1, @endDate) AND(spa.RESULT_TEST_NUM = @addendaCode {13}) AND(res.RESULT_TEST_NUM = @dxCode) AND spa.ACCESSION LIKE @prefixSelection AND(spa.RESULT LIKE @keyword {14} {15} {16}) AND res.ECR_STATUS NOT LIKE 'n' AND cli.FAKE_CLIENT LIKE 'n' UNION /*addenda where parent report has been ECR'd*/ SELECT IIF(spa.ECR_STATUS LIKE 'n', 'X', '') AS[ECR'd], spa.RESULT_TEST_MNEMONIC AS [RPT. SEC.], spa.ACCESSION AS [CASE #], replace(replace(spa.RESULT,char(13),' '),char(10),' ') as [RESULT], his.PREV_VER_WHEN AS [VERIFIED], emp.LAST_NAME + ', ' + emp.FIRST_NAME AS [PATHOLOGIST], pat.SEX, IIF(pat.BIRTH_WHEN <= '1900 - 01 - 01','U',convert(char(3),FLOOR(DATEDIFF(day,pat.BIRTH_WHEN,his.PREV_VER_WHEN)/365.242199))) as [AGE/VERIFIED], IIF(pat.BIRTH_WHEN <= '1900 - 01 - 01','U',convert(char(3),FLOOR(DATEDIFF(day,pat.BIRTH_WHEN,@currentDate)/365.242199))) as [AGE/TODAY], pat.REQ_NUM as [MRN] FROM server.schema.resultTable AS spa INNER JOIN server.schema.resultTable AS res ON spa.ACCESSION = res.ACCESSION INNER JOIN server.schema.historicResultTable AS his ON(res.ACCESSION = his.ACCESSION AND res.RESULT_TEST_NUM = his.RESULT_TEST_NUM) INNER JOIN server.schema.employeeTable AS emp  ON spa.VER_BY = emp.EMPLOYEE_ID INNER JOIN server.schema.patientTable AS pat ON spa.ENCOUNTER = pat.ENCOUNTER INNER JOIN server.schema.clientTable as cli ON spa.CLIENT_ID = cli.CLIENT_ID WHERE his.PREV_VER_WHEN >= @startDate and his.PREV_VER_WHEN <= dateadd(d, 1, @endDate) AND his.PREV_RESULT_STAT not like 'c' AND(spa.RESULT_TEST_NUM = @addendaCode {13}) AND(res.RESULT_TEST_NUM = @dxCode) AND spa.ACCESSION LIKE @prefixSelection AND(spa.RESULT LIKE @keyword {14} {15} {16}) AND res.ECR_STATUS LIKE 'n' AND cli.FAKE_CLIENT LIKE 'n' {17}) ORDER BY [CASE #]", startDate, endDate, dxCode, prefixSelection, keyword, andKeyword, orKeyword, notKeyword, addendaCode, reportAnd, reportOr, reportNot, addendaBracket1, oldHemeAddenda, addendaAnd, addendaOr, addendaNot, addendaBracket2);
            }
            else
            {
                sqlQuery = String.Format("declare @startDate date = '{0}' declare @endDate date = '{1}' declare @currentDate datetime = GETDATE() declare @dxCode char(7) = '{2}' declare @prefixSelection char(3) = '{3}%' declare @keyword varchar(max) = '%{4}%' declare @andWord varchar(max) = '%{5}%' declare @orWord varchar(max) = '%{6}%' declare @notWord varchar(max) = '%{7}%' declare @addendaCode varchar(max) = '{8}' (SELECT IIF(res.ECR_STATUS LIKE 'n', 'X', '') AS [ECR'd],res.RESULT_TEST_MNEMONIC AS [RPT. SEC.], his.ACCESSION as [CASE #], replace(replace(res.RESULT,char(13),' '),char(10),' ') as [RESULT], his.PREV_VER_WHEN AS [VERIFIED], emp.LAST_NAME + ', ' + emp.FIRST_NAME AS [PATHOLOGIST], pat.SEX, IIF(pat.BIRTH_WHEN <= '1900-01-01','U',convert(char(3),FLOOR(DATEDIFF(day,pat.BIRTH_WHEN,his.PREV_VER_WHEN)/365.242199))) as [AGE/VERIFIED], IIF(pat.BIRTH_WHEN <= '1900-01-01','U',convert(char(3),FLOOR(DATEDIFF(day,pat.BIRTH_WHEN,@currentDate)/365.242199))) as [AGE/TODAY] FROM server.schema.historicResultTable AS his INNER JOIN server.schema.resultTable AS res ON (his.ACCESSION = res.ACCESSION AND his.RESULT_TEST_NUM = res.RESULT_TEST_NUM) INNER JOIN server.schema.employeeTableemp ON res.VER_BY = emp.EMPLOYEE_ID INNER JOIN server.schema.patientTable AS pat ON res.ENCOUNTER = pat.ENCOUNTER INNER JOIN server.schema.clientTable as cli ON res.CLIENT_ID = cli.CLIENT_ID WHERE his.PREV_VER_WHEN >= @startDate and his.PREV_VER_WHEN <= dateadd(d,1,@endDate) AND his.PREV_RESULT_STAT not like 'c' AND (res.RESULT_TEST_NUM = @dxCode) AND his.ACCESSION LIKE @prefixSelection AND (res.RESULT LIKE @keyword {9} {10} {11}) AND cli.FAKE_CLIENT LIKE 'n' AND res.ECR_STATUS like 'n' AND FLOOR(DATEDIFF(day,pat.BIRTH_WHEN,@currentDate)/365.242199) < 90 UNION SELECT IIF(res.ECR_STATUS LIKE 'n', 'X', '') AS [ECR'd], res.RESULT_TEST_MNEMONIC AS [RPT. SEC.], res.ACCESSION as [CASE #], replace(replace(res.RESULT,char(13),' '),char(10),' ') as [RESULT], res.VER_WHEN AS [VERIFIED], emp.LAST_NAME + ', ' + emp.FIRST_NAME AS [PATHOLOGIST], pat.SEX, IIF(pat.BIRTH_WHEN <= '1900-01-01','U',convert(char(3),FLOOR(DATEDIFF(day,pat.BIRTH_WHEN,res.VER_WHEN)/365.242199))) AS [AGE/VERIFIED], IIF(pat.BIRTH_WHEN <= '1900-01-01','U',convert(char(3),FLOOR(DATEDIFF(day,pat.BIRTH_WHEN,@currentDate)/365.242199))) AS [AGE/TODAY] FROM server.schema.resultTable AS res INNER JOIN server.schema.employeeTableemp ON res.VER_BY = emp.EMPLOYEE_ID INNER JOIN server.schema.patientTable AS pat ON res.ENCOUNTER = pat.ENCOUNTER INNER JOIN server.schema.clientTable as cli ON res.CLIENT_ID = cli.CLIENT_ID WHERE res.VER_WHEN >= @startDate AND res.VER_WHEN <= dateadd(d, 1, @endDate) AND (res.RESULT_TEST_NUM = @dxCode) AND res.ACCESSION LIKE @prefixSelection AND (res.RESULT LIKE @keyword {9} {10} {11}) AND res.ECR_STATUS NOT LIKE 'n' AND cli.FAKE_CLIENT LIKE 'n' AND FLOOR(DATEDIFF(day,pat.BIRTH_WHEN,@currentDate)/365.242199) < 90 {12} UNION SELECT IIF(spa.ECR_STATUS LIKE 'n', 'X', '') AS[ECR'd], spa.RESULT_TEST_MNEMONIC AS [RPT. SEC.], spa.ACCESSION AS [CASE #], replace(replace(spa.RESULT,char(13),' '),char(10),' ') as [RESULT], res.VER_WHEN AS [VERIFIED], emp.LAST_NAME + ', ' + emp.FIRST_NAME AS [PATHOLOGIST], pat.SEX, IIF(pat.BIRTH_WHEN <= '1900-01-01', 'U', convert(char(3), FLOOR(DATEDIFF(day, pat.BIRTH_WHEN, res.VER_WHEN) / 365.242199))) as [AGE / VERIFIED], IIF(pat.BIRTH_WHEN <= '1900-01-01', 'U', convert(char(3), FLOOR(DATEDIFF(day, pat.BIRTH_WHEN, @currentDate) / 365.242199))) as [AGE / TODAY] FROM server.schema.resultTable AS spa INNER JOIN server.schema.resultTable AS res ON spa.ACCESSION = res.ACCESSION INNER JOIN server.schema.employeeTableAS emp ON spa.VER_BY = emp.EMPLOYEE_ID INNER JOIN server.schema.patientTable AS pat ON spa.ENCOUNTER = pat.ENCOUNTER INNER JOIN server.schema.clientTable as cli ON spa.CLIENT_ID = cli.CLIENT_ID  WHERE res.VER_WHEN >= @startDate and res.VER_WHEN <= dateadd(d, 1, @endDate) AND(spa.RESULT_TEST_NUM = @addendaCode {13}) AND(res.RESULT_TEST_NUM = @dxCode) AND spa.ACCESSION LIKE @prefixSelection AND(spa.RESULT LIKE @keyword {14} {15} {16}) AND res.ECR_STATUS NOT LIKE 'n' AND cli.FAKE_CLIENT LIKE 'n' AND FLOOR(DATEDIFF(day,pat.BIRTH_WHEN, @currentDate)/365.242199) < 90 UNION /*addenda where parent report has been ECR'd*/ SELECT IIF(spa.ECR_STATUS LIKE 'n', 'X', '') AS[ECR'd], spa.RESULT_TEST_MNEMONIC AS [RPT. SEC.], spa.ACCESSION AS [CASE #], replace(replace(spa.RESULT,char(13),' '),char(10),' ') as [RESULT], his.PREV_VER_WHEN AS [VERIFIED], emp.LAST_NAME + ', ' + emp.FIRST_NAME AS [PATHOLOGIST], pat.SEX, IIF(pat.BIRTH_WHEN <= '1900 - 01 - 01','U',convert(char(3),FLOOR(DATEDIFF(day,pat.BIRTH_WHEN,his.PREV_VER_WHEN)/365.242199))) as [AGE/VERIFIED], IIF(pat.BIRTH_WHEN <= '1900 - 01 - 01','U',convert(char(3),FLOOR(DATEDIFF(day,pat.BIRTH_WHEN,@currentDate)/365.242199))) as [AGE/TODAY] FROM server.schema.resultTable AS spa INNER JOIN server.schema.resultTable AS res ON spa.ACCESSION = res.ACCESSION INNER JOIN server.schema.historicResultTable AS his ON(res.ACCESSION = his.ACCESSION AND res.RESULT_TEST_NUM = his.RESULT_TEST_NUM) INNER JOIN server.schema.employeeTableAS emp  ON spa.VER_BY = emp.EMPLOYEE_ID INNER JOIN server.schema.patientTable AS pat ON spa.ENCOUNTER = pat.ENCOUNTER INNER JOIN server.schema.clientTable as cli ON spa.CLIENT_ID = cli.CLIENT_ID WHERE his.PREV_VER_WHEN >= @startDate and his.PREV_VER_WHEN <= dateadd(d, 1, @endDate) AND his.PREV_RESULT_STAT not like 'c' AND(spa.RESULT_TEST_NUM = @addendaCode {13}) AND(res.RESULT_TEST_NUM = @dxCode) AND spa.ACCESSION LIKE @prefixSelection AND(spa.RESULT LIKE @keyword {14} {15} {16}) AND res.ECR_STATUS LIKE 'n' AND cli.FAKE_CLIENT LIKE 'n' AND FLOOR(DATEDIFF(day,pat.BIRTH_WHEN,@currentDate)/365.242199) < 90 {17}) ORDER BY [CASE #]", startDate, endDate, dxCode, prefixSelection, keyword, andKeyword, orKeyword, notKeyword, addendaCode, reportAnd, reportOr, reportNot, addendaBracket1, oldHemeAddenda, addendaAnd, addendaOr, addendaNot, addendaBracket2);
            }

            //MessageBox.Show(sqlQuery, "ALERT!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return sqlQuery;
        }
        private void ExecuteSearch()
        {

            string query = SQLQueryBuilder();

            //both using cases are supposed to handle the opening and closing of connection
            using (connection = new SqlConnection(connectionString))
            {
                if (connection.State != ConnectionState.Open) //this is a maybe in case the connection gets hung up; may need to also check if state = connecting
                {
                    connection.Close();
                    connection.Open();
                }

                using (adapter = new SqlDataAdapter(query, connection))
                {
                    adapter.SelectCommand.CommandTimeout = 600;

                    adapter.Fill(queryDataTable);

                    /*
                     * Example test code demonsrating how to apply additional filters to the results after the search has completed.
                     * Loads results to a DataView then performs SQL-esque searches to filter, then converts back to a datatable.
                     * Tips on filter commands: http://www.csharp-examples.net/dataview-rowfilter/
                     */
                    //DataView tempViewTbl = new DataView(dtbl);
                    //tempViewTbl.RowFilter = "result LIKE '%perforation%'";

                    //dtbl = tempViewTbl.ToTable();
                    //tempViewTbl = null;
                }

            }

            if (connection.State != ConnectionState.Closed) //check and close connection after search just to be safe.
            {
                connection.Close();
            }
        }

        private void searchBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            _stopwatch.Restart();
            try
            {
                ExecuteSearch();
            }
            catch (Exception ex)

            {
                searchBackgroundWorker.ReportProgress((int)_stopwatch.ElapsedTicks);
                searchBackgroundWorker.CancelAsync();
                if (!cancelled)
                    MessageBox.Show(ex.Message, "Something happened...");
            }
            _stopwatch.Stop();
        }

        private void searchBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            searchTimer.Stop();
            loadingBar.Visible = false;
            searchStopButton.BackgroundImage = Properties.Resources.icons8_binoculars_32;
            refreshButton.Visible = true;
            if (cancelled)
            {
                stopWatchText.Visible = false;
                MessageBox.Show("Search stopped by user.", "NOTICE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cancelled = false;
            }
            else
            {
                resultsGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                resultsGrid.DataSource = queryDataTable;
                resultsGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;

                for (int i = 0; i < resultsGrid.ColumnCount; i++)
                {
                    if (resultsGrid.Columns[i].Name == "ECR'd" || resultsGrid.Columns[i].Name == "SEX")
                    {
                        resultsGrid.Columns[i].Width = 60;
                    }
                    else
                    {
                        resultsGrid.Columns[i].Width = 120;
                    }
                }

                if (resultsGrid.RowCount > 0)
                {
                    resultsGrid.Visible = true;
                    rowCount.Text = String.Format("Rows: {0:#,#}", resultsGrid.RowCount.ToString("#,#", CultureInfo.InvariantCulture));
                    excelGlowButton.Visible = true;
                }
                else
                {
                    rowCount.Text = "Rows: None";
                }

                rowCount.Visible = true;
                stopWatchText.Text = _stopwatch.Elapsed.ToString(@"mm\:ss\.ff");
            }
            if(!ContainsFocus) //https://stackoverflow.com/questions/7162834/determine-if-current-application-is-activated-has-focus
            {
                searchNotifyIcon.BalloonTipText = String.Format("Search Complete\n{0}\nTimer: {1}", rowCount.Text.ToString(),stopWatchText.Text.ToString());
                searchNotifyIcon.ShowBalloonTip(100);
            }
        }

        private void searchTimer_Tick(object sender, EventArgs e)
        {
            stopWatchText.Text = _stopwatch.Elapsed.ToString(@"mm\:ss\.ff");
        }

        private void excelGlowButton_Click(object sender, EventArgs e)
        {
            endDatePicker.Visible = false;
            startDatePicker.Visible = false;
            queryDataTable.AcceptChanges();
            ExportToExcel(queryDataTable);
        }

        private void ExportToExcel(DataTable DataTable, string ExcelFilePath = null)
        { //https://stackoverflow.com/a/21079709
            try
            {
                int ColumnsCount;

                if (DataTable == null || (ColumnsCount = DataTable.Columns.Count) == 0)
                    throw new Exception("ExportToExcel: Null or empty input table!\n");

                // load excel, and create a new workbook
                ExcelInterop.Application Excel = new ExcelInterop.Application();
                Excel.Workbooks.Add();

                // single worksheet
                ExcelInterop._Worksheet Worksheet = Excel.ActiveSheet;

                object[] Header = new object[ColumnsCount];

                // column headings               
                for (int i = 0; i < ColumnsCount; i++)
                    Header[i] = DataTable.Columns[i].ColumnName;

                ExcelInterop.Range HeaderRange = Worksheet.get_Range((ExcelInterop.Range)(Worksheet.Cells[1, 1]), (ExcelInterop.Range)(Worksheet.Cells[1, ColumnsCount]));
                HeaderRange.Value = Header;
                HeaderRange.Interior.Color = ColorTranslator.ToOle(Color.Indigo);
                HeaderRange.Font.Color = ColorTranslator.ToOle(Color.White);
                HeaderRange.Font.Bold = true;


                //https://stackoverflow.com/a/5060552
                //Freeze header to lock on top when scrolling
                Worksheet.Activate();
                Worksheet.Application.ActiveWindow.SplitRow = 1;
                Worksheet.Application.ActiveWindow.FreezePanes = true;

                int RowsCount = DataTable.Rows.Count;
                object[,] Cells = new object[RowsCount, ColumnsCount];

                for (int j = 0; j < RowsCount; j++)
                    for (int i = 0; i < ColumnsCount; i++)
                        Cells[j, i] = DataTable.Rows[j][i];

                Worksheet.get_Range((ExcelInterop.Range)(Worksheet.Cells[2, 1]), (ExcelInterop.Range)(Worksheet.Cells[RowsCount + 1, ColumnsCount])).Value = Cells;

                Worksheet.Cells.Style.HorizontalAlignment = ExcelInterop.XlHAlign.xlHAlignLeft;
                Worksheet.Cells.Style.VerticalAlignment = ExcelInterop.XlVAlign.xlVAlignTop;
                Worksheet.Columns.AutoFit();

                for (int i = 1; i <= ColumnsCount; i++)
                {
                    if (Worksheet.Columns[i].ColumnWidth > 84)
                        Worksheet.Columns[i].ColumnWidth = 84;
                }
                Worksheet.Cells.WrapText = true;

                Excel.Visible = true; //delete if auto-save logic is uncommented and applied

                /* 
                 Code will go through the sheet, locate keywords searched for, turn them red, and set to bold.
                 Works well except it slows down the export severely.
                 */
                //https://msdn.microsoft.com/en-us/library/e4x1k99a.aspx & https://stackoverflow.com/a/10401233
                /* Excel.Range currentFind = null;
                 Excel.Range firstFind = null;
                 string text = "biopsy";
                 // Find the first occurrence of the passed-in text

                 currentFind = Worksheet.Cells.Find(text, Missing.Value, Microsoft.Office.Interop.Excel.XlFindLookIn.xlValues,
                     Microsoft.Office.Interop.Excel.XlLookAt.xlPart, Microsoft.Office.Interop.Excel.XlSearchOrder.xlByRows, 
                     Microsoft.Office.Interop.Excel.XlSearchDirection.xlNext,
                     false, Missing.Value, Missing.Value);

                 while (currentFind != null)
                 {
                     // Keep track of the first range we find

                     if (firstFind == null)
                     {
                         firstFind = currentFind;
                     }
                     else if (currentFind.get_Address(Missing.Value, Missing.Value, Microsoft.Office.Interop.Excel.XlReferenceStyle.xlA1,
                         Missing.Value, Missing.Value) ==
                         firstFind.get_Address(Missing.Value, Missing.Value, Microsoft.Office.Interop.Excel.XlReferenceStyle.xlA1,
                         Missing.Value, Missing.Value))
                     {
                         // We didn't move to a new range so we're done

                         break;
                     }

                     // We know our text is in first cell of this range, so we need to narrow down its position

                     string searchResult = currentFind.get_Range("A1").Value.ToString().ToLower();
                     //int startPos = searchResult.IndexOf(text);
                     List<int> positionList = Program.AllIndexesOf(searchResult, text);
                     // Set the text in the cell to bold
                     foreach (var position in positionList)
                     {
                         currentFind.get_Range("A1").Characters[position + 1, text.Length].Font.Bold = true;
                         currentFind.get_Range("A1").Characters[position + 1, text.Length].Font.Color = ColorTranslator.ToOle(Color.Red);
                     }


                     // Move to the next find

                     currentFind = Worksheet.Cells.FindNext(currentFind);
                 } */

                // check fielpath logic in case auto-save-to destination is provided
                //    if (ExcelFilePath != null && ExcelFilePath != "")
                //    {
                //        try
                //        {
                //            Worksheet.SaveAs(ExcelFilePath);
                //            Excel.Quit();
                //            MessageBox.Show("Excel file saved!");
                //        }
                //        catch (Exception ex)
                //        {
                //            throw new Exception("ExportToExcel: Excel file could not be saved! Check filepath.\n"
                //                + ex.Message);
                //        }
                //    }
                //    else    // no filepath is given
                //    {
                //        Excel.Visible = true;
                //    }
            }
            catch (Exception ex)
            {
                throw new Exception("ExportToExcel: \n" + ex.Message);
            }

        }

        private void prefixComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            prefixSelection = prefixComboBox.SelectedItem.ToString().Trim();
        }

        private void phiModeButton_Click(object sender, EventArgs e)
        {
            if (phiMode)
            {
                phiMode = false;
                phiModeButton.BackgroundImage = Properties.Resources.icons8_switch_off_32;
                phiModeLabel.Text = "phi mode off";


            } else
            {
                phiMode = true;
                phiModeButton.BackgroundImage = Properties.Resources.icons8_switch_on_32;
                phiModeLabel.Text = "phi mode on";
            }
        }



        //private Color SuperDarkPurple()
        //{
        //    Color superDarkPurple = new Color();
        //    superDarkPurple = Color.FromArgb(20, 0, 29);
        //    return superDarkPurple;
        //}
        //protected override void OnPaintBackground(PaintEventArgs e)
        //{

        //    using (LinearGradientBrush linGradBrush = new LinearGradientBrush(this.ClientRectangle, SuperDarkPurple(), Color.Black, 90F))
        //    {
        //        Graphics g = e.Graphics;
        //        g.FillRectangle(linGradBrush, this.ClientRectangle);
        //        base.OnPaint(e);
        //    }
        //}

    }
}
