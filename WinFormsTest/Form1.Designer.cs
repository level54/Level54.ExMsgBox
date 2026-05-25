namespace WinFormsTest;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        grpCore = new GroupBox();
        flpCore = new FlowLayoutPanel();
        btnSimple = new Button();
        btnThrown = new Button();
        btnNested2 = new Button();
        btnNested3 = new Button();
        btnSql = new Button();
        btnSqlInner = new Button();
        btnAdvanced = new Button();
        btnLong = new Button();
        grpButtons = new GroupBox();
        flpButtons = new FlowLayoutPanel();
        btnBtnsOk = new Button();
        btnBtnsOkCancel = new Button();
        btnBtnsYesNo = new Button();
        btnBtnsYesNoCancel = new Button();
        btnBtnsRetryCancel = new Button();
        btnBtnsAbortRetryIgnore = new Button();
        grpSymbols = new GroupBox();
        flpSymbols = new FlowLayoutPanel();
        btnSymError = new Button();
        btnSymWarning = new Button();
        btnSymInformation = new Button();
        btnSymQuestion = new Button();
        grpOptional = new GroupBox();
        flpOptional = new FlowLayoutPanel();
        btnCheckBox = new Button();
        btnHelpLink = new Button();
        btnNoToolbar = new Button();
        grpCore.SuspendLayout();
        flpCore.SuspendLayout();
        grpButtons.SuspendLayout();
        flpButtons.SuspendLayout();
        grpSymbols.SuspendLayout();
        flpSymbols.SuspendLayout();
        grpOptional.SuspendLayout();
        flpOptional.SuspendLayout();
        SuspendLayout();
        // 
        // grpCore
        // 
        grpCore.Controls.Add(flpCore);
        grpCore.Location = new Point(12, 12);
        grpCore.Name = "grpCore";
        grpCore.Size = new Size(700, 169);
        grpCore.TabIndex = 0;
        grpCore.TabStop = false;
        grpCore.Text = "Core states";
        // 
        // flpCore
        // 
        flpCore.Controls.Add(btnSimple);
        flpCore.Controls.Add(btnThrown);
        flpCore.Controls.Add(btnNested2);
        flpCore.Controls.Add(btnNested3);
        flpCore.Controls.Add(btnSql);
        flpCore.Controls.Add(btnSqlInner);
        flpCore.Controls.Add(btnAdvanced);
        flpCore.Controls.Add(btnLong);
        flpCore.Dock = DockStyle.Fill;
        flpCore.Location = new Point(3, 35);
        flpCore.Name = "flpCore";
        flpCore.Padding = new Padding(4);
        flpCore.Size = new Size(694, 131);
        flpCore.TabIndex = 0;
        // 
        // btnSimple
        // 
        btnSimple.Location = new Point(8, 8);
        btnSimple.Margin = new Padding(4);
        btnSimple.Name = "btnSimple";
        btnSimple.Size = new Size(160, 50);
        btnSimple.TabIndex = 0;
        btnSimple.Text = "Simple message";
        btnSimple.UseVisualStyleBackColor = true;
        btnSimple.Click += btnSimple_Click;
        // 
        // btnThrown
        // 
        btnThrown.Location = new Point(176, 8);
        btnThrown.Margin = new Padding(4);
        btnThrown.Name = "btnThrown";
        btnThrown.Size = new Size(160, 50);
        btnThrown.TabIndex = 1;
        btnThrown.Text = "Thrown (stack trace)";
        btnThrown.UseVisualStyleBackColor = true;
        btnThrown.Click += btnThrown_Click;
        // 
        // btnNested2
        // 
        btnNested2.Location = new Point(344, 8);
        btnNested2.Margin = new Padding(4);
        btnNested2.Name = "btnNested2";
        btnNested2.Size = new Size(160, 50);
        btnNested2.TabIndex = 2;
        btnNested2.Text = "Nested 2 levels";
        btnNested2.UseVisualStyleBackColor = true;
        btnNested2.Click += btnNested2_Click;
        // 
        // btnNested3
        // 
        btnNested3.Location = new Point(512, 8);
        btnNested3.Margin = new Padding(4);
        btnNested3.Name = "btnNested3";
        btnNested3.Size = new Size(160, 50);
        btnNested3.TabIndex = 3;
        btnNested3.Text = "Nested 3 levels";
        btnNested3.UseVisualStyleBackColor = true;
        btnNested3.Click += btnNested3_Click;
        // 
        // btnSql
        // 
        btnSql.Location = new Point(8, 66);
        btnSql.Margin = new Padding(4);
        btnSql.Name = "btnSql";
        btnSql.Size = new Size(160, 50);
        btnSql.TabIndex = 4;
        btnSql.Text = "SqlException";
        btnSql.UseVisualStyleBackColor = true;
        btnSql.Click += btnSql_Click;
        // 
        // btnSqlInner
        // 
        btnSqlInner.Location = new Point(176, 66);
        btnSqlInner.Margin = new Padding(4);
        btnSqlInner.Name = "btnSqlInner";
        btnSqlInner.Size = new Size(160, 50);
        btnSqlInner.TabIndex = 5;
        btnSqlInner.Text = "SqlException (inner)";
        btnSqlInner.UseVisualStyleBackColor = true;
        btnSqlInner.Click += btnSqlInner_Click;
        // 
        // btnAdvanced
        // 
        btnAdvanced.Location = new Point(344, 66);
        btnAdvanced.Margin = new Padding(4);
        btnAdvanced.Name = "btnAdvanced";
        btnAdvanced.Size = new Size(160, 50);
        btnAdvanced.TabIndex = 6;
        btnAdvanced.Text = "AdvancedInformation.*";
        btnAdvanced.UseVisualStyleBackColor = true;
        btnAdvanced.Click += btnAdvanced_Click;
        // 
        // btnLong
        // 
        btnLong.Location = new Point(512, 66);
        btnLong.Margin = new Padding(4);
        btnLong.Name = "btnLong";
        btnLong.Size = new Size(160, 50);
        btnLong.TabIndex = 7;
        btnLong.Text = "Long wrapping message";
        btnLong.UseVisualStyleBackColor = true;
        btnLong.Click += btnLong_Click;
        // 
        // grpButtons
        // 
        grpButtons.Controls.Add(flpButtons);
        grpButtons.Location = new Point(12, 196);
        grpButtons.Name = "grpButtons";
        grpButtons.Size = new Size(700, 171);
        grpButtons.TabIndex = 1;
        grpButtons.TabStop = false;
        grpButtons.Text = "Button sets";
        // 
        // flpButtons
        // 
        flpButtons.Controls.Add(btnBtnsOk);
        flpButtons.Controls.Add(btnBtnsOkCancel);
        flpButtons.Controls.Add(btnBtnsYesNo);
        flpButtons.Controls.Add(btnBtnsYesNoCancel);
        flpButtons.Controls.Add(btnBtnsRetryCancel);
        flpButtons.Controls.Add(btnBtnsAbortRetryIgnore);
        flpButtons.Dock = DockStyle.Fill;
        flpButtons.Location = new Point(3, 35);
        flpButtons.Name = "flpButtons";
        flpButtons.Padding = new Padding(4);
        flpButtons.Size = new Size(694, 133);
        flpButtons.TabIndex = 0;
        // 
        // btnBtnsOk
        // 
        btnBtnsOk.Location = new Point(8, 8);
        btnBtnsOk.Margin = new Padding(4);
        btnBtnsOk.Name = "btnBtnsOk";
        btnBtnsOk.Size = new Size(160, 50);
        btnBtnsOk.TabIndex = 0;
        btnBtnsOk.Text = "OK";
        btnBtnsOk.UseVisualStyleBackColor = true;
        btnBtnsOk.Click += btnBtnsOk_Click;
        // 
        // btnBtnsOkCancel
        // 
        btnBtnsOkCancel.Location = new Point(176, 8);
        btnBtnsOkCancel.Margin = new Padding(4);
        btnBtnsOkCancel.Name = "btnBtnsOkCancel";
        btnBtnsOkCancel.Size = new Size(160, 50);
        btnBtnsOkCancel.TabIndex = 1;
        btnBtnsOkCancel.Text = "OKCancel";
        btnBtnsOkCancel.UseVisualStyleBackColor = true;
        btnBtnsOkCancel.Click += btnBtnsOkCancel_Click;
        // 
        // btnBtnsYesNo
        // 
        btnBtnsYesNo.Location = new Point(344, 8);
        btnBtnsYesNo.Margin = new Padding(4);
        btnBtnsYesNo.Name = "btnBtnsYesNo";
        btnBtnsYesNo.Size = new Size(160, 50);
        btnBtnsYesNo.TabIndex = 2;
        btnBtnsYesNo.Text = "YesNo";
        btnBtnsYesNo.UseVisualStyleBackColor = true;
        btnBtnsYesNo.Click += btnBtnsYesNo_Click;
        // 
        // btnBtnsYesNoCancel
        // 
        btnBtnsYesNoCancel.Location = new Point(512, 8);
        btnBtnsYesNoCancel.Margin = new Padding(4);
        btnBtnsYesNoCancel.Name = "btnBtnsYesNoCancel";
        btnBtnsYesNoCancel.Size = new Size(160, 50);
        btnBtnsYesNoCancel.TabIndex = 3;
        btnBtnsYesNoCancel.Text = "YesNoCancel";
        btnBtnsYesNoCancel.UseVisualStyleBackColor = true;
        btnBtnsYesNoCancel.Click += btnBtnsYesNoCancel_Click;
        // 
        // btnBtnsRetryCancel
        // 
        btnBtnsRetryCancel.Location = new Point(8, 66);
        btnBtnsRetryCancel.Margin = new Padding(4);
        btnBtnsRetryCancel.Name = "btnBtnsRetryCancel";
        btnBtnsRetryCancel.Size = new Size(160, 50);
        btnBtnsRetryCancel.TabIndex = 4;
        btnBtnsRetryCancel.Text = "RetryCancel";
        btnBtnsRetryCancel.UseVisualStyleBackColor = true;
        btnBtnsRetryCancel.Click += btnBtnsRetryCancel_Click;
        // 
        // btnBtnsAbortRetryIgnore
        // 
        btnBtnsAbortRetryIgnore.Location = new Point(176, 66);
        btnBtnsAbortRetryIgnore.Margin = new Padding(4);
        btnBtnsAbortRetryIgnore.Name = "btnBtnsAbortRetryIgnore";
        btnBtnsAbortRetryIgnore.Size = new Size(160, 50);
        btnBtnsAbortRetryIgnore.TabIndex = 5;
        btnBtnsAbortRetryIgnore.Text = "AbortRetryIgnore";
        btnBtnsAbortRetryIgnore.UseVisualStyleBackColor = true;
        btnBtnsAbortRetryIgnore.Click += btnBtnsAbortRetryIgnore_Click;
        // 
        // grpSymbols
        // 
        grpSymbols.Controls.Add(flpSymbols);
        grpSymbols.Location = new Point(12, 373);
        grpSymbols.Name = "grpSymbols";
        grpSymbols.Size = new Size(700, 110);
        grpSymbols.TabIndex = 2;
        grpSymbols.TabStop = false;
        grpSymbols.Text = "Symbols";
        // 
        // flpSymbols
        // 
        flpSymbols.Controls.Add(btnSymError);
        flpSymbols.Controls.Add(btnSymWarning);
        flpSymbols.Controls.Add(btnSymInformation);
        flpSymbols.Controls.Add(btnSymQuestion);
        flpSymbols.Dock = DockStyle.Fill;
        flpSymbols.Location = new Point(3, 35);
        flpSymbols.Name = "flpSymbols";
        flpSymbols.Padding = new Padding(4);
        flpSymbols.Size = new Size(694, 72);
        flpSymbols.TabIndex = 0;
        // 
        // btnSymError
        // 
        btnSymError.Location = new Point(8, 8);
        btnSymError.Margin = new Padding(4);
        btnSymError.Name = "btnSymError";
        btnSymError.Size = new Size(160, 50);
        btnSymError.TabIndex = 0;
        btnSymError.Text = "Error";
        btnSymError.UseVisualStyleBackColor = true;
        btnSymError.Click += btnSymError_Click;
        // 
        // btnSymWarning
        // 
        btnSymWarning.Location = new Point(176, 8);
        btnSymWarning.Margin = new Padding(4);
        btnSymWarning.Name = "btnSymWarning";
        btnSymWarning.Size = new Size(160, 50);
        btnSymWarning.TabIndex = 1;
        btnSymWarning.Text = "Warning";
        btnSymWarning.UseVisualStyleBackColor = true;
        btnSymWarning.Click += btnSymWarning_Click;
        // 
        // btnSymInformation
        // 
        btnSymInformation.Location = new Point(344, 8);
        btnSymInformation.Margin = new Padding(4);
        btnSymInformation.Name = "btnSymInformation";
        btnSymInformation.Size = new Size(160, 50);
        btnSymInformation.TabIndex = 2;
        btnSymInformation.Text = "Information";
        btnSymInformation.UseVisualStyleBackColor = true;
        btnSymInformation.Click += btnSymInformation_Click;
        // 
        // btnSymQuestion
        // 
        btnSymQuestion.Location = new Point(512, 8);
        btnSymQuestion.Margin = new Padding(4);
        btnSymQuestion.Name = "btnSymQuestion";
        btnSymQuestion.Size = new Size(160, 50);
        btnSymQuestion.TabIndex = 3;
        btnSymQuestion.Text = "Question";
        btnSymQuestion.UseVisualStyleBackColor = true;
        btnSymQuestion.Click += btnSymQuestion_Click;
        // 
        // grpOptional
        // 
        grpOptional.Controls.Add(flpOptional);
        grpOptional.Location = new Point(12, 489);
        grpOptional.Name = "grpOptional";
        grpOptional.Size = new Size(700, 114);
        grpOptional.TabIndex = 3;
        grpOptional.TabStop = false;
        grpOptional.Text = "Optional features";
        // 
        // flpOptional
        // 
        flpOptional.Controls.Add(btnCheckBox);
        flpOptional.Controls.Add(btnHelpLink);
        flpOptional.Controls.Add(btnNoToolbar);
        flpOptional.Dock = DockStyle.Fill;
        flpOptional.Location = new Point(3, 35);
        flpOptional.Name = "flpOptional";
        flpOptional.Padding = new Padding(4);
        flpOptional.Size = new Size(694, 76);
        flpOptional.TabIndex = 0;
        // 
        // btnCheckBox
        // 
        btnCheckBox.Location = new Point(8, 8);
        btnCheckBox.Margin = new Padding(4);
        btnCheckBox.Name = "btnCheckBox";
        btnCheckBox.Size = new Size(160, 50);
        btnCheckBox.TabIndex = 0;
        btnCheckBox.Text = "ShowCheckBox";
        btnCheckBox.UseVisualStyleBackColor = true;
        btnCheckBox.Click += btnCheckBox_Click;
        // 
        // btnHelpLink
        // 
        btnHelpLink.Location = new Point(176, 8);
        btnHelpLink.Margin = new Padding(4);
        btnHelpLink.Name = "btnHelpLink";
        btnHelpLink.Size = new Size(160, 50);
        btnHelpLink.TabIndex = 1;
        btnHelpLink.Text = "HelpLink URL";
        btnHelpLink.UseVisualStyleBackColor = true;
        btnHelpLink.Click += btnHelpLink_Click;
        // 
        // btnNoToolbar
        // 
        btnNoToolbar.Location = new Point(344, 8);
        btnNoToolbar.Margin = new Padding(4);
        btnNoToolbar.Name = "btnNoToolbar";
        btnNoToolbar.Size = new Size(160, 50);
        btnNoToolbar.TabIndex = 2;
        btnNoToolbar.Text = "ShowToolBar = false";
        btnNoToolbar.UseVisualStyleBackColor = true;
        btnNoToolbar.Click += btnNoToolbar_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(13F, 32F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(724, 617);
        Controls.Add(grpOptional);
        Controls.Add(grpSymbols);
        Controls.Add(grpButtons);
        Controls.Add(grpCore);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        Name = "Form1";
        Text = "Level54.ExMsgBox — Native dialog (.NET 10)";
        grpCore.ResumeLayout(false);
        flpCore.ResumeLayout(false);
        grpButtons.ResumeLayout(false);
        flpButtons.ResumeLayout(false);
        grpSymbols.ResumeLayout(false);
        flpSymbols.ResumeLayout(false);
        grpOptional.ResumeLayout(false);
        flpOptional.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private GroupBox grpCore;
    private FlowLayoutPanel flpCore;
    private Button btnSimple;
    private Button btnThrown;
    private Button btnNested2;
    private Button btnNested3;
    private Button btnSql;
    private Button btnSqlInner;
    private Button btnAdvanced;
    private Button btnLong;

    private GroupBox grpButtons;
    private FlowLayoutPanel flpButtons;
    private Button btnBtnsOk;
    private Button btnBtnsOkCancel;
    private Button btnBtnsYesNo;
    private Button btnBtnsYesNoCancel;
    private Button btnBtnsRetryCancel;
    private Button btnBtnsAbortRetryIgnore;

    private GroupBox grpSymbols;
    private FlowLayoutPanel flpSymbols;
    private Button btnSymError;
    private Button btnSymWarning;
    private Button btnSymInformation;
    private Button btnSymQuestion;

    private GroupBox grpOptional;
    private FlowLayoutPanel flpOptional;
    private Button btnCheckBox;
    private Button btnHelpLink;
    private Button btnNoToolbar;
}
