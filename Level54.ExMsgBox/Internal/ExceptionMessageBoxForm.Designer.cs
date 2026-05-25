namespace Level54.ExMsgBox.Internal
{
    partial class ExceptionMessageBoxForm
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
            rootLayout = new TableLayoutPanel();
            pnlBody = new TableLayoutPanel();
            pnlIcon = new PictureBox();
            messageStack = new FlowLayoutPanel();
            lblPrimaryMessage = new Label();
            lblAdditionalInfoHeader = new Label();
            flpInnerExceptions = new FlowLayoutPanel();
            chkDontShow = new CheckBox();
            pnlSeparator = new Panel();
            pnlFooter = new Panel();
            flpButtons = new FlowLayoutPanel();
            btn1 = new Button();
            btn2 = new Button();
            btn3 = new Button();
            btn4 = new Button();
            btn5 = new Button();
            flpActions = new FlowLayoutPanel();
            btnHelp = new Button();
            btnCopy = new Button();
            btnDetails = new Button();
            rootLayout.SuspendLayout();
            pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlIcon).BeginInit();
            messageStack.SuspendLayout();
            pnlFooter.SuspendLayout();
            flpButtons.SuspendLayout();
            flpActions.SuspendLayout();
            SuspendLayout();
            // 
            // rootLayout
            // 
            rootLayout.AutoSize = true;
            rootLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            rootLayout.ColumnCount = 1;
            rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 1040F));
            rootLayout.Controls.Add(pnlBody, 0, 0);
            rootLayout.Controls.Add(pnlSeparator, 0, 1);
            rootLayout.Controls.Add(pnlFooter, 0, 2);
            rootLayout.Dock = DockStyle.Top;
            rootLayout.Location = new Point(0, 0);
            rootLayout.Margin = new Padding(5);
            rootLayout.Name = "rootLayout";
            rootLayout.RowCount = 3;
            rootLayout.RowStyles.Add(new RowStyle());
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 2F));
            rootLayout.RowStyles.Add(new RowStyle());
            rootLayout.Size = new Size(1072, 264);
            rootLayout.TabIndex = 0;
            // 
            // pnlBody
            // 
            pnlBody.AutoSize = true;
            pnlBody.BackColor = SystemColors.Window;
            pnlBody.ColumnCount = 2;
            pnlBody.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 91F));
            pnlBody.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pnlBody.Controls.Add(pnlIcon, 0, 0);
            pnlBody.Controls.Add(messageStack, 1, 0);
            pnlBody.Controls.Add(chkDontShow, 1, 1);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 0);
            pnlBody.Margin = new Padding(0);
            pnlBody.Name = "pnlBody";
            pnlBody.Padding = new Padding(26, 24, 26, 24);
            pnlBody.RowCount = 2;
            pnlBody.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlBody.RowStyles.Add(new RowStyle());
            pnlBody.Size = new Size(1072, 174);
            pnlBody.TabIndex = 0;
            // 
            // pnlIcon
            // 
            pnlIcon.Location = new Point(31, 29);
            pnlIcon.Margin = new Padding(5);
            pnlIcon.Name = "pnlIcon";
            pnlIcon.Size = new Size(72, 72);
            pnlIcon.TabIndex = 0;
            pnlIcon.TabStop = false;
            // 
            // messageStack
            // 
            messageStack.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            messageStack.AutoSize = true;
            messageStack.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            messageStack.Controls.Add(lblPrimaryMessage);
            messageStack.Controls.Add(lblAdditionalInfoHeader);
            messageStack.Controls.Add(flpInnerExceptions);
            messageStack.FlowDirection = FlowDirection.TopDown;
            messageStack.Location = new Point(117, 24);
            messageStack.Margin = new Padding(0);
            messageStack.Name = "messageStack";
            messageStack.Size = new Size(929, 90);
            messageStack.TabIndex = 1;
            messageStack.WrapContents = false;
            // 
            // lblPrimaryMessage
            // 
            lblPrimaryMessage.AutoSize = true;
            lblPrimaryMessage.Location = new Point(0, 0);
            lblPrimaryMessage.Margin = new Padding(0, 0, 0, 13);
            lblPrimaryMessage.MaximumSize = new Size(894, 0);
            lblPrimaryMessage.Name = "lblPrimaryMessage";
            lblPrimaryMessage.Size = new Size(194, 32);
            lblPrimaryMessage.TabIndex = 0;
            lblPrimaryMessage.Text = "Primary message";
            // 
            // lblAdditionalInfoHeader
            // 
            lblAdditionalInfoHeader.AutoSize = true;
            lblAdditionalInfoHeader.Font = new Font("Microsoft Sans Serif", 7.875F, FontStyle.Bold);
            lblAdditionalInfoHeader.Location = new Point(0, 45);
            lblAdditionalInfoHeader.Margin = new Padding(0, 0, 0, 7);
            lblAdditionalInfoHeader.Name = "lblAdditionalInfoHeader";
            lblAdditionalInfoHeader.Size = new Size(248, 25);
            lblAdditionalInfoHeader.TabIndex = 1;
            lblAdditionalInfoHeader.Text = "Additional information:";
            lblAdditionalInfoHeader.Visible = false;
            // 
            // flpInnerExceptions
            // 
            flpInnerExceptions.AutoSize = true;
            flpInnerExceptions.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpInnerExceptions.FlowDirection = FlowDirection.TopDown;
            flpInnerExceptions.Location = new Point(0, 77);
            flpInnerExceptions.Margin = new Padding(0, 0, 0, 13);
            flpInnerExceptions.Name = "flpInnerExceptions";
            flpInnerExceptions.Size = new Size(0, 0);
            flpInnerExceptions.TabIndex = 2;
            flpInnerExceptions.Visible = false;
            flpInnerExceptions.WrapContents = false;
            // 
            // chkDontShow
            // 
            chkDontShow.AutoSize = true;
            chkDontShow.Location = new Point(117, 114);
            chkDontShow.Margin = new Padding(0);
            chkDontShow.Name = "chkDontShow";
            chkDontShow.Size = new Size(377, 36);
            chkDontShow.TabIndex = 3;
            chkDontShow.Text = "Don't show this message again";
            chkDontShow.UseVisualStyleBackColor = true;
            chkDontShow.Visible = false;
            // 
            // pnlSeparator
            // 
            pnlSeparator.BackColor = SystemColors.ControlDark;
            pnlSeparator.Dock = DockStyle.Fill;
            pnlSeparator.Location = new Point(0, 174);
            pnlSeparator.Margin = new Padding(0);
            pnlSeparator.Name = "pnlSeparator";
            pnlSeparator.Size = new Size(1072, 2);
            pnlSeparator.TabIndex = 1;
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = SystemColors.Control;
            pnlFooter.Controls.Add(flpButtons);
            pnlFooter.Controls.Add(flpActions);
            pnlFooter.Dock = DockStyle.Fill;
            pnlFooter.Location = new Point(0, 176);
            pnlFooter.Margin = new Padding(0);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Padding = new Padding(15);
            pnlFooter.Size = new Size(1072, 88);
            pnlFooter.TabIndex = 2;
            // 
            // flpButtons
            // 
            flpButtons.AutoSize = true;
            flpButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpButtons.Controls.Add(btn1);
            flpButtons.Controls.Add(btn2);
            flpButtons.Controls.Add(btn3);
            flpButtons.Controls.Add(btn4);
            flpButtons.Controls.Add(btn5);
            flpButtons.Dock = DockStyle.Right;
            flpButtons.FlowDirection = FlowDirection.RightToLeft;
            flpButtons.Location = new Point(257, 15);
            flpButtons.Margin = new Padding(0);
            flpButtons.Name = "flpButtons";
            flpButtons.Size = new Size(800, 58);
            flpButtons.TabIndex = 1;
            flpButtons.WrapContents = false;
            // 
            // btn1
            // 
            btn1.AutoSize = true;
            btn1.Location = new Point(650, 2);
            btn1.Margin = new Padding(10, 2, 0, 2);
            btn1.Name = "btn1";
            btn1.Size = new Size(150, 56);
            btn1.TabIndex = 0;
            btn1.Text = "B1";
            btn1.UseVisualStyleBackColor = true;
            // 
            // btn2
            // 
            btn2.AutoSize = true;
            btn2.Location = new Point(490, 2);
            btn2.Margin = new Padding(10, 2, 0, 2);
            btn2.Name = "btn2";
            btn2.Size = new Size(150, 56);
            btn2.TabIndex = 1;
            btn2.Text = "B2";
            btn2.UseVisualStyleBackColor = true;
            // 
            // btn3
            // 
            btn3.AutoSize = true;
            btn3.Location = new Point(330, 2);
            btn3.Margin = new Padding(10, 2, 0, 2);
            btn3.Name = "btn3";
            btn3.Size = new Size(150, 56);
            btn3.TabIndex = 2;
            btn3.Text = "B3";
            btn3.UseVisualStyleBackColor = true;
            // 
            // btn4
            // 
            btn4.AutoSize = true;
            btn4.Location = new Point(170, 2);
            btn4.Margin = new Padding(10, 2, 0, 2);
            btn4.Name = "btn4";
            btn4.Size = new Size(150, 56);
            btn4.TabIndex = 3;
            btn4.Text = "B4";
            btn4.UseVisualStyleBackColor = true;
            // 
            // btn5
            // 
            btn5.AutoSize = true;
            btn5.Location = new Point(10, 2);
            btn5.Margin = new Padding(10, 2, 0, 2);
            btn5.Name = "btn5";
            btn5.Size = new Size(150, 56);
            btn5.TabIndex = 4;
            btn5.Text = "B5";
            btn5.UseVisualStyleBackColor = true;
            // 
            // flpActions
            // 
            flpActions.AutoSize = true;
            flpActions.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpActions.Controls.Add(btnHelp);
            flpActions.Controls.Add(btnCopy);
            flpActions.Controls.Add(btnDetails);
            flpActions.Dock = DockStyle.Left;
            flpActions.Location = new Point(15, 15);
            flpActions.Margin = new Padding(0);
            flpActions.Name = "flpActions";
            flpActions.Size = new Size(557, 58);
            flpActions.TabIndex = 0;
            flpActions.WrapContents = false;
            // 
            // btnHelp
            // 
            btnHelp.AutoSize = true;
            btnHelp.FlatAppearance.BorderSize = 0;
            btnHelp.FlatStyle = FlatStyle.Flat;
            btnHelp.Image = Properties.Resources.Help32;
            btnHelp.Location = new Point(5, 0);
            btnHelp.Margin = new Padding(5, 0, 10, 0);
            btnHelp.Name = "btnHelp";
            btnHelp.Size = new Size(106, 58);
            btnHelp.TabIndex = 0;
            btnHelp.Text = "Help";
            btnHelp.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnHelp.UseVisualStyleBackColor = true;
            btnHelp.Visible = false;
            // 
            // btnCopy
            // 
            btnCopy.AutoSize = true;
            btnCopy.FlatAppearance.BorderSize = 0;
            btnCopy.FlatStyle = FlatStyle.Flat;
            btnCopy.Image = Properties.Resources.CopyToClipboard24;
            btnCopy.Location = new Point(126, 0);
            btnCopy.Margin = new Padding(5, 0, 10, 0);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new Size(211, 58);
            btnCopy.TabIndex = 1;
            btnCopy.Text = "Copy message";
            btnCopy.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCopy.UseVisualStyleBackColor = true;
            // 
            // btnDetails
            // 
            btnDetails.AutoSize = true;
            btnDetails.FlatAppearance.BorderSize = 0;
            btnDetails.FlatStyle = FlatStyle.Flat;
            btnDetails.Image = Properties.Resources.ShowDetail32;
            btnDetails.Location = new Point(352, 0);
            btnDetails.Margin = new Padding(5, 0, 10, 0);
            btnDetails.Name = "btnDetails";
            btnDetails.Size = new Size(195, 58);
            btnDetails.TabIndex = 2;
            btnDetails.Text = "Show details";
            btnDetails.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDetails.UseVisualStyleBackColor = true;
            btnDetails.Visible = false;
            // 
            // ExceptionMessageBoxForm
            // 
            AutoScaleDimensions = new SizeF(192F, 192F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1072, 262);
            Controls.Add(rootLayout);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            KeyPreview = true;
            Margin = new Padding(5);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(1072, 255);
            Name = "ExceptionMessageBoxForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Error";
            rootLayout.ResumeLayout(false);
            rootLayout.PerformLayout();
            pnlBody.ResumeLayout(false);
            pnlBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlIcon).EndInit();
            messageStack.ResumeLayout(false);
            messageStack.PerformLayout();
            pnlFooter.ResumeLayout(false);
            pnlFooter.PerformLayout();
            flpButtons.ResumeLayout(false);
            flpButtons.PerformLayout();
            flpActions.ResumeLayout(false);
            flpActions.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel rootLayout;
        private System.Windows.Forms.TableLayoutPanel pnlBody;
        private System.Windows.Forms.PictureBox pnlIcon;
        private System.Windows.Forms.FlowLayoutPanel messageStack;
        private System.Windows.Forms.Label lblPrimaryMessage;
        private System.Windows.Forms.Label lblAdditionalInfoHeader;
        private System.Windows.Forms.FlowLayoutPanel flpInnerExceptions;
        private System.Windows.Forms.CheckBox chkDontShow;
        private System.Windows.Forms.Panel pnlSeparator;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.FlowLayoutPanel flpButtons;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.FlowLayoutPanel flpActions;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.Button btnHelp;
    }
}
