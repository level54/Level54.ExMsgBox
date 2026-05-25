namespace WinFormsTest472
{
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
            this.grpCore = new System.Windows.Forms.GroupBox();
            this.flpCore = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSimple = new System.Windows.Forms.Button();
            this.btnThrown = new System.Windows.Forms.Button();
            this.btnNested2 = new System.Windows.Forms.Button();
            this.btnNested3 = new System.Windows.Forms.Button();
            this.btnSql = new System.Windows.Forms.Button();
            this.btnSqlInner = new System.Windows.Forms.Button();
            this.btnAdvanced = new System.Windows.Forms.Button();
            this.btnLong = new System.Windows.Forms.Button();
            this.grpButtons = new System.Windows.Forms.GroupBox();
            this.flpButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnBtnsOk = new System.Windows.Forms.Button();
            this.btnBtnsOkCancel = new System.Windows.Forms.Button();
            this.btnBtnsYesNo = new System.Windows.Forms.Button();
            this.btnBtnsYesNoCancel = new System.Windows.Forms.Button();
            this.btnBtnsRetryCancel = new System.Windows.Forms.Button();
            this.btnBtnsAbortRetryIgnore = new System.Windows.Forms.Button();
            this.grpSymbols = new System.Windows.Forms.GroupBox();
            this.flpSymbols = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSymError = new System.Windows.Forms.Button();
            this.btnSymWarning = new System.Windows.Forms.Button();
            this.btnSymInformation = new System.Windows.Forms.Button();
            this.btnSymQuestion = new System.Windows.Forms.Button();
            this.grpOptional = new System.Windows.Forms.GroupBox();
            this.flpOptional = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCheckBox = new System.Windows.Forms.Button();
            this.btnHelpLink = new System.Windows.Forms.Button();
            this.btnNoToolbar = new System.Windows.Forms.Button();
            this.grpCore.SuspendLayout();
            this.flpCore.SuspendLayout();
            this.grpButtons.SuspendLayout();
            this.flpButtons.SuspendLayout();
            this.grpSymbols.SuspendLayout();
            this.flpSymbols.SuspendLayout();
            this.grpOptional.SuspendLayout();
            this.flpOptional.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpCore
            // 
            this.grpCore.Controls.Add(this.flpCore);
            this.grpCore.Location = new System.Drawing.Point(23, 12);
            this.grpCore.Name = "grpCore";
            this.grpCore.Size = new System.Drawing.Size(700, 131);
            this.grpCore.TabIndex = 0;
            this.grpCore.TabStop = false;
            this.grpCore.Text = "Core states";
            // 
            // flpCore
            // 
            this.flpCore.Controls.Add(this.btnSimple);
            this.flpCore.Controls.Add(this.btnThrown);
            this.flpCore.Controls.Add(this.btnNested2);
            this.flpCore.Controls.Add(this.btnNested3);
            this.flpCore.Controls.Add(this.btnSql);
            this.flpCore.Controls.Add(this.btnSqlInner);
            this.flpCore.Controls.Add(this.btnAdvanced);
            this.flpCore.Controls.Add(this.btnLong);
            this.flpCore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpCore.Location = new System.Drawing.Point(3, 27);
            this.flpCore.Name = "flpCore";
            this.flpCore.Padding = new System.Windows.Forms.Padding(4);
            this.flpCore.Size = new System.Drawing.Size(694, 101);
            this.flpCore.TabIndex = 0;
            // 
            // btnSimple
            // 
            this.btnSimple.Location = new System.Drawing.Point(8, 8);
            this.btnSimple.Margin = new System.Windows.Forms.Padding(4);
            this.btnSimple.Name = "btnSimple";
            this.btnSimple.Size = new System.Drawing.Size(160, 32);
            this.btnSimple.TabIndex = 0;
            this.btnSimple.Text = "Simple message";
            this.btnSimple.UseVisualStyleBackColor = true;
            this.btnSimple.Click += new System.EventHandler(this.btnSimple_Click);
            // 
            // btnThrown
            // 
            this.btnThrown.Location = new System.Drawing.Point(176, 8);
            this.btnThrown.Margin = new System.Windows.Forms.Padding(4);
            this.btnThrown.Name = "btnThrown";
            this.btnThrown.Size = new System.Drawing.Size(160, 32);
            this.btnThrown.TabIndex = 1;
            this.btnThrown.Text = "Thrown (stack trace)";
            this.btnThrown.UseVisualStyleBackColor = true;
            this.btnThrown.Click += new System.EventHandler(this.btnThrown_Click);
            // 
            // btnNested2
            // 
            this.btnNested2.Location = new System.Drawing.Point(344, 8);
            this.btnNested2.Margin = new System.Windows.Forms.Padding(4);
            this.btnNested2.Name = "btnNested2";
            this.btnNested2.Size = new System.Drawing.Size(160, 32);
            this.btnNested2.TabIndex = 2;
            this.btnNested2.Text = "Nested 2 levels";
            this.btnNested2.UseVisualStyleBackColor = true;
            this.btnNested2.Click += new System.EventHandler(this.btnNested2_Click);
            // 
            // btnNested3
            // 
            this.btnNested3.Location = new System.Drawing.Point(512, 8);
            this.btnNested3.Margin = new System.Windows.Forms.Padding(4);
            this.btnNested3.Name = "btnNested3";
            this.btnNested3.Size = new System.Drawing.Size(160, 32);
            this.btnNested3.TabIndex = 3;
            this.btnNested3.Text = "Nested 3 levels";
            this.btnNested3.UseVisualStyleBackColor = true;
            this.btnNested3.Click += new System.EventHandler(this.btnNested3_Click);
            // 
            // btnSql
            // 
            this.btnSql.Location = new System.Drawing.Point(8, 48);
            this.btnSql.Margin = new System.Windows.Forms.Padding(4);
            this.btnSql.Name = "btnSql";
            this.btnSql.Size = new System.Drawing.Size(160, 32);
            this.btnSql.TabIndex = 4;
            this.btnSql.Text = "SqlException";
            this.btnSql.UseVisualStyleBackColor = true;
            this.btnSql.Click += new System.EventHandler(this.btnSql_Click);
            // 
            // btnSqlInner
            // 
            this.btnSqlInner.Location = new System.Drawing.Point(176, 48);
            this.btnSqlInner.Margin = new System.Windows.Forms.Padding(4);
            this.btnSqlInner.Name = "btnSqlInner";
            this.btnSqlInner.Size = new System.Drawing.Size(160, 32);
            this.btnSqlInner.TabIndex = 5;
            this.btnSqlInner.Text = "SqlException (inner)";
            this.btnSqlInner.UseVisualStyleBackColor = true;
            this.btnSqlInner.Click += new System.EventHandler(this.btnSqlInner_Click);
            // 
            // btnAdvanced
            // 
            this.btnAdvanced.Location = new System.Drawing.Point(344, 48);
            this.btnAdvanced.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdvanced.Name = "btnAdvanced";
            this.btnAdvanced.Size = new System.Drawing.Size(160, 32);
            this.btnAdvanced.TabIndex = 6;
            this.btnAdvanced.Text = "AdvancedInformation.*";
            this.btnAdvanced.UseVisualStyleBackColor = true;
            this.btnAdvanced.Click += new System.EventHandler(this.btnAdvanced_Click);
            // 
            // btnLong
            // 
            this.btnLong.Location = new System.Drawing.Point(512, 48);
            this.btnLong.Margin = new System.Windows.Forms.Padding(4);
            this.btnLong.Name = "btnLong";
            this.btnLong.Size = new System.Drawing.Size(160, 32);
            this.btnLong.TabIndex = 7;
            this.btnLong.Text = "Long wrapping message";
            this.btnLong.UseVisualStyleBackColor = true;
            this.btnLong.Click += new System.EventHandler(this.btnLong_Click);
            // 
            // grpButtons
            // 
            this.grpButtons.Controls.Add(this.flpButtons);
            this.grpButtons.Location = new System.Drawing.Point(23, 158);
            this.grpButtons.Name = "grpButtons";
            this.grpButtons.Size = new System.Drawing.Size(700, 80);
            this.grpButtons.TabIndex = 1;
            this.grpButtons.TabStop = false;
            this.grpButtons.Text = "Button sets";
            // 
            // flpButtons
            // 
            this.flpButtons.Controls.Add(this.btnBtnsOk);
            this.flpButtons.Controls.Add(this.btnBtnsOkCancel);
            this.flpButtons.Controls.Add(this.btnBtnsYesNo);
            this.flpButtons.Controls.Add(this.btnBtnsYesNoCancel);
            this.flpButtons.Controls.Add(this.btnBtnsRetryCancel);
            this.flpButtons.Controls.Add(this.btnBtnsAbortRetryIgnore);
            this.flpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpButtons.Location = new System.Drawing.Point(3, 27);
            this.flpButtons.Name = "flpButtons";
            this.flpButtons.Padding = new System.Windows.Forms.Padding(4);
            this.flpButtons.Size = new System.Drawing.Size(694, 50);
            this.flpButtons.TabIndex = 0;
            // 
            // btnBtnsOk
            // 
            this.btnBtnsOk.Location = new System.Drawing.Point(8, 8);
            this.btnBtnsOk.Margin = new System.Windows.Forms.Padding(4);
            this.btnBtnsOk.Name = "btnBtnsOk";
            this.btnBtnsOk.Size = new System.Drawing.Size(160, 32);
            this.btnBtnsOk.TabIndex = 0;
            this.btnBtnsOk.Text = "OK";
            this.btnBtnsOk.UseVisualStyleBackColor = true;
            this.btnBtnsOk.Click += new System.EventHandler(this.btnBtnsOk_Click);
            // 
            // btnBtnsOkCancel
            // 
            this.btnBtnsOkCancel.Location = new System.Drawing.Point(176, 8);
            this.btnBtnsOkCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnBtnsOkCancel.Name = "btnBtnsOkCancel";
            this.btnBtnsOkCancel.Size = new System.Drawing.Size(160, 32);
            this.btnBtnsOkCancel.TabIndex = 1;
            this.btnBtnsOkCancel.Text = "OKCancel";
            this.btnBtnsOkCancel.UseVisualStyleBackColor = true;
            this.btnBtnsOkCancel.Click += new System.EventHandler(this.btnBtnsOkCancel_Click);
            // 
            // btnBtnsYesNo
            // 
            this.btnBtnsYesNo.Location = new System.Drawing.Point(344, 8);
            this.btnBtnsYesNo.Margin = new System.Windows.Forms.Padding(4);
            this.btnBtnsYesNo.Name = "btnBtnsYesNo";
            this.btnBtnsYesNo.Size = new System.Drawing.Size(160, 32);
            this.btnBtnsYesNo.TabIndex = 2;
            this.btnBtnsYesNo.Text = "YesNo";
            this.btnBtnsYesNo.UseVisualStyleBackColor = true;
            this.btnBtnsYesNo.Click += new System.EventHandler(this.btnBtnsYesNo_Click);
            // 
            // btnBtnsYesNoCancel
            // 
            this.btnBtnsYesNoCancel.Location = new System.Drawing.Point(512, 8);
            this.btnBtnsYesNoCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnBtnsYesNoCancel.Name = "btnBtnsYesNoCancel";
            this.btnBtnsYesNoCancel.Size = new System.Drawing.Size(160, 32);
            this.btnBtnsYesNoCancel.TabIndex = 3;
            this.btnBtnsYesNoCancel.Text = "YesNoCancel";
            this.btnBtnsYesNoCancel.UseVisualStyleBackColor = true;
            this.btnBtnsYesNoCancel.Click += new System.EventHandler(this.btnBtnsYesNoCancel_Click);
            // 
            // btnBtnsRetryCancel
            // 
            this.btnBtnsRetryCancel.Location = new System.Drawing.Point(8, 48);
            this.btnBtnsRetryCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnBtnsRetryCancel.Name = "btnBtnsRetryCancel";
            this.btnBtnsRetryCancel.Size = new System.Drawing.Size(160, 32);
            this.btnBtnsRetryCancel.TabIndex = 4;
            this.btnBtnsRetryCancel.Text = "RetryCancel";
            this.btnBtnsRetryCancel.UseVisualStyleBackColor = true;
            this.btnBtnsRetryCancel.Click += new System.EventHandler(this.btnBtnsRetryCancel_Click);
            // 
            // btnBtnsAbortRetryIgnore
            // 
            this.btnBtnsAbortRetryIgnore.Location = new System.Drawing.Point(176, 48);
            this.btnBtnsAbortRetryIgnore.Margin = new System.Windows.Forms.Padding(4);
            this.btnBtnsAbortRetryIgnore.Name = "btnBtnsAbortRetryIgnore";
            this.btnBtnsAbortRetryIgnore.Size = new System.Drawing.Size(160, 32);
            this.btnBtnsAbortRetryIgnore.TabIndex = 5;
            this.btnBtnsAbortRetryIgnore.Text = "AbortRetryIgnore";
            this.btnBtnsAbortRetryIgnore.UseVisualStyleBackColor = true;
            this.btnBtnsAbortRetryIgnore.Click += new System.EventHandler(this.btnBtnsAbortRetryIgnore_Click);
            // 
            // grpSymbols
            // 
            this.grpSymbols.Controls.Add(this.flpSymbols);
            this.grpSymbols.Location = new System.Drawing.Point(23, 253);
            this.grpSymbols.Name = "grpSymbols";
            this.grpSymbols.Size = new System.Drawing.Size(700, 85);
            this.grpSymbols.TabIndex = 2;
            this.grpSymbols.TabStop = false;
            this.grpSymbols.Text = "Symbols";
            // 
            // flpSymbols
            // 
            this.flpSymbols.Controls.Add(this.btnSymError);
            this.flpSymbols.Controls.Add(this.btnSymWarning);
            this.flpSymbols.Controls.Add(this.btnSymInformation);
            this.flpSymbols.Controls.Add(this.btnSymQuestion);
            this.flpSymbols.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpSymbols.Location = new System.Drawing.Point(3, 27);
            this.flpSymbols.Name = "flpSymbols";
            this.flpSymbols.Padding = new System.Windows.Forms.Padding(4);
            this.flpSymbols.Size = new System.Drawing.Size(694, 55);
            this.flpSymbols.TabIndex = 0;
            // 
            // btnSymError
            // 
            this.btnSymError.Location = new System.Drawing.Point(8, 8);
            this.btnSymError.Margin = new System.Windows.Forms.Padding(4);
            this.btnSymError.Name = "btnSymError";
            this.btnSymError.Size = new System.Drawing.Size(160, 32);
            this.btnSymError.TabIndex = 0;
            this.btnSymError.Text = "Error";
            this.btnSymError.UseVisualStyleBackColor = true;
            this.btnSymError.Click += new System.EventHandler(this.btnSymError_Click);
            // 
            // btnSymWarning
            // 
            this.btnSymWarning.Location = new System.Drawing.Point(176, 8);
            this.btnSymWarning.Margin = new System.Windows.Forms.Padding(4);
            this.btnSymWarning.Name = "btnSymWarning";
            this.btnSymWarning.Size = new System.Drawing.Size(160, 32);
            this.btnSymWarning.TabIndex = 1;
            this.btnSymWarning.Text = "Warning";
            this.btnSymWarning.UseVisualStyleBackColor = true;
            this.btnSymWarning.Click += new System.EventHandler(this.btnSymWarning_Click);
            // 
            // btnSymInformation
            // 
            this.btnSymInformation.Location = new System.Drawing.Point(344, 8);
            this.btnSymInformation.Margin = new System.Windows.Forms.Padding(4);
            this.btnSymInformation.Name = "btnSymInformation";
            this.btnSymInformation.Size = new System.Drawing.Size(160, 32);
            this.btnSymInformation.TabIndex = 2;
            this.btnSymInformation.Text = "Information";
            this.btnSymInformation.UseVisualStyleBackColor = true;
            this.btnSymInformation.Click += new System.EventHandler(this.btnSymInformation_Click);
            // 
            // btnSymQuestion
            // 
            this.btnSymQuestion.Location = new System.Drawing.Point(512, 8);
            this.btnSymQuestion.Margin = new System.Windows.Forms.Padding(4);
            this.btnSymQuestion.Name = "btnSymQuestion";
            this.btnSymQuestion.Size = new System.Drawing.Size(160, 32);
            this.btnSymQuestion.TabIndex = 3;
            this.btnSymQuestion.Text = "Question";
            this.btnSymQuestion.UseVisualStyleBackColor = true;
            this.btnSymQuestion.Click += new System.EventHandler(this.btnSymQuestion_Click);
            // 
            // grpOptional
            // 
            this.grpOptional.Controls.Add(this.flpOptional);
            this.grpOptional.Location = new System.Drawing.Point(26, 344);
            this.grpOptional.Name = "grpOptional";
            this.grpOptional.Size = new System.Drawing.Size(700, 82);
            this.grpOptional.TabIndex = 3;
            this.grpOptional.TabStop = false;
            this.grpOptional.Text = "Optional features";
            // 
            // flpOptional
            // 
            this.flpOptional.Controls.Add(this.btnCheckBox);
            this.flpOptional.Controls.Add(this.btnHelpLink);
            this.flpOptional.Controls.Add(this.btnNoToolbar);
            this.flpOptional.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpOptional.Location = new System.Drawing.Point(3, 27);
            this.flpOptional.Name = "flpOptional";
            this.flpOptional.Padding = new System.Windows.Forms.Padding(4);
            this.flpOptional.Size = new System.Drawing.Size(694, 52);
            this.flpOptional.TabIndex = 0;
            // 
            // btnCheckBox
            // 
            this.btnCheckBox.Location = new System.Drawing.Point(8, 8);
            this.btnCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.btnCheckBox.Name = "btnCheckBox";
            this.btnCheckBox.Size = new System.Drawing.Size(160, 32);
            this.btnCheckBox.TabIndex = 0;
            this.btnCheckBox.Text = "ShowCheckBox";
            this.btnCheckBox.UseVisualStyleBackColor = true;
            this.btnCheckBox.Click += new System.EventHandler(this.btnCheckBox_Click);
            // 
            // btnHelpLink
            // 
            this.btnHelpLink.Location = new System.Drawing.Point(176, 8);
            this.btnHelpLink.Margin = new System.Windows.Forms.Padding(4);
            this.btnHelpLink.Name = "btnHelpLink";
            this.btnHelpLink.Size = new System.Drawing.Size(160, 32);
            this.btnHelpLink.TabIndex = 1;
            this.btnHelpLink.Text = "HelpLink URL";
            this.btnHelpLink.UseVisualStyleBackColor = true;
            this.btnHelpLink.Click += new System.EventHandler(this.btnHelpLink_Click);
            // 
            // btnNoToolbar
            // 
            this.btnNoToolbar.Location = new System.Drawing.Point(344, 8);
            this.btnNoToolbar.Margin = new System.Windows.Forms.Padding(4);
            this.btnNoToolbar.Name = "btnNoToolbar";
            this.btnNoToolbar.Size = new System.Drawing.Size(160, 32);
            this.btnNoToolbar.TabIndex = 2;
            this.btnNoToolbar.Text = "ShowToolBar = false";
            this.btnNoToolbar.UseVisualStyleBackColor = true;
            this.btnNoToolbar.Click += new System.EventHandler(this.btnNoToolbar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 441);
            this.Controls.Add(this.grpOptional);
            this.Controls.Add(this.grpSymbols);
            this.Controls.Add(this.grpButtons);
            this.Controls.Add(this.grpCore);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Microsoft Exception Dialog Reference (FX 4.7.2)";
            this.grpCore.ResumeLayout(false);
            this.flpCore.ResumeLayout(false);
            this.grpButtons.ResumeLayout(false);
            this.flpButtons.ResumeLayout(false);
            this.grpSymbols.ResumeLayout(false);
            this.flpSymbols.ResumeLayout(false);
            this.grpOptional.ResumeLayout(false);
            this.flpOptional.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpCore;
        private System.Windows.Forms.FlowLayoutPanel flpCore;
        private System.Windows.Forms.Button btnSimple;
        private System.Windows.Forms.Button btnThrown;
        private System.Windows.Forms.Button btnNested2;
        private System.Windows.Forms.Button btnNested3;
        private System.Windows.Forms.Button btnSql;
        private System.Windows.Forms.Button btnSqlInner;
        private System.Windows.Forms.Button btnAdvanced;
        private System.Windows.Forms.Button btnLong;

        private System.Windows.Forms.GroupBox grpButtons;
        private System.Windows.Forms.FlowLayoutPanel flpButtons;
        private System.Windows.Forms.Button btnBtnsOk;
        private System.Windows.Forms.Button btnBtnsOkCancel;
        private System.Windows.Forms.Button btnBtnsYesNo;
        private System.Windows.Forms.Button btnBtnsYesNoCancel;
        private System.Windows.Forms.Button btnBtnsRetryCancel;
        private System.Windows.Forms.Button btnBtnsAbortRetryIgnore;

        private System.Windows.Forms.GroupBox grpSymbols;
        private System.Windows.Forms.FlowLayoutPanel flpSymbols;
        private System.Windows.Forms.Button btnSymError;
        private System.Windows.Forms.Button btnSymWarning;
        private System.Windows.Forms.Button btnSymInformation;
        private System.Windows.Forms.Button btnSymQuestion;

        private System.Windows.Forms.GroupBox grpOptional;
        private System.Windows.Forms.FlowLayoutPanel flpOptional;
        private System.Windows.Forms.Button btnCheckBox;
        private System.Windows.Forms.Button btnHelpLink;
        private System.Windows.Forms.Button btnNoToolbar;
    }
}
