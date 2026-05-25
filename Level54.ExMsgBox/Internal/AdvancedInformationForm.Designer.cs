namespace Level54.ExMsgBox.Internal
{
    partial class AdvancedInformationForm
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
            pnlFooter = new Panel();
            btnClose = new Button();
            btnCopy = new Button();
            pnlDetail = new Panel();
            txtDetails = new TextBox();
            lblDetails = new Label();
            pnlMessage = new Panel();
            tvComponents = new TreeView();
            lblMessageComponent = new Label();
            rootLayout.SuspendLayout();
            pnlFooter.SuspendLayout();
            pnlDetail.SuspendLayout();
            pnlMessage.SuspendLayout();
            SuspendLayout();
            // 
            // rootLayout
            // 
            rootLayout.ColumnCount = 2;
            rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            rootLayout.Controls.Add(pnlFooter, 1, 1);
            rootLayout.Controls.Add(pnlDetail, 1, 0);
            rootLayout.Controls.Add(pnlMessage, 0, 0);
            rootLayout.Dock = DockStyle.Fill;
            rootLayout.Location = new Point(0, 0);
            rootLayout.Margin = new Padding(72, 30, 72, 30);
            rootLayout.Name = "rootLayout";
            rootLayout.RowCount = 2;
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            rootLayout.Size = new Size(1198, 867);
            rootLayout.TabIndex = 0;
            // 
            // pnlFooter
            // 
            pnlFooter.Controls.Add(btnClose);
            pnlFooter.Controls.Add(btnCopy);
            pnlFooter.Dock = DockStyle.Fill;
            pnlFooter.Location = new Point(419, 767);
            pnlFooter.Margin = new Padding(0);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(779, 100);
            pnlFooter.TabIndex = 1;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.DialogResult = DialogResult.OK;
            btnClose.Location = new Point(543, 21);
            btnClose.MinimumSize = new Size(215, 60);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(215, 60);
            btnClose.TabIndex = 0;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // btnCopy
            // 
            btnCopy.FlatAppearance.BorderSize = 0;
            btnCopy.FlatStyle = FlatStyle.Flat;
            btnCopy.Image = Properties.Resources.CopyToClipboard32;
            btnCopy.Location = new Point(13, 12);
            btnCopy.MinimumSize = new Size(261, 66);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new Size(261, 66);
            btnCopy.TabIndex = 1;
            btnCopy.Text = "Copy to clipboard";
            btnCopy.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCopy.UseVisualStyleBackColor = true;
            // 
            // pnlDetail
            // 
            pnlDetail.Controls.Add(txtDetails);
            pnlDetail.Controls.Add(lblDetails);
            pnlDetail.Dock = DockStyle.Fill;
            pnlDetail.Location = new Point(422, 3);
            pnlDetail.Name = "pnlDetail";
            pnlDetail.Padding = new Padding(10);
            pnlDetail.Size = new Size(773, 761);
            pnlDetail.TabIndex = 2;
            // 
            // txtDetails
            // 
            txtDetails.Dock = DockStyle.Fill;
            txtDetails.Font = new Font("Consolas", 9F);
            txtDetails.Location = new Point(10, 45);
            txtDetails.Margin = new Padding(72, 30, 72, 30);
            txtDetails.Multiline = true;
            txtDetails.Name = "txtDetails";
            txtDetails.ReadOnly = true;
            txtDetails.ScrollBars = ScrollBars.Both;
            txtDetails.Size = new Size(753, 706);
            txtDetails.TabIndex = 2;
            txtDetails.WordWrap = false;
            // 
            // lblDetails
            // 
            lblDetails.Dock = DockStyle.Top;
            lblDetails.Location = new Point(10, 10);
            lblDetails.Margin = new Padding(0);
            lblDetails.Name = "lblDetails";
            lblDetails.Size = new Size(753, 35);
            lblDetails.TabIndex = 1;
            lblDetails.Text = "Details:";
            // 
            // pnlMessage
            // 
            pnlMessage.Controls.Add(tvComponents);
            pnlMessage.Controls.Add(lblMessageComponent);
            pnlMessage.Dock = DockStyle.Fill;
            pnlMessage.Location = new Point(3, 3);
            pnlMessage.Name = "pnlMessage";
            pnlMessage.Padding = new Padding(10);
            pnlMessage.Size = new Size(413, 761);
            pnlMessage.TabIndex = 3;
            // 
            // tvComponents
            // 
            tvComponents.Dock = DockStyle.Fill;
            tvComponents.HideSelection = false;
            tvComponents.Location = new Point(10, 45);
            tvComponents.Margin = new Padding(72, 30, 72, 30);
            tvComponents.Name = "tvComponents";
            tvComponents.Size = new Size(393, 706);
            tvComponents.TabIndex = 2;
            // 
            // lblMessageComponent
            // 
            lblMessageComponent.Dock = DockStyle.Top;
            lblMessageComponent.Location = new Point(10, 10);
            lblMessageComponent.Margin = new Padding(0);
            lblMessageComponent.Name = "lblMessageComponent";
            lblMessageComponent.Size = new Size(393, 35);
            lblMessageComponent.TabIndex = 1;
            lblMessageComponent.Text = "Message component:";
            // 
            // AdvancedInformationForm
            // 
            AcceptButton = btnClose;
            AutoScaleDimensions = new SizeF(192F, 192F);
            AutoScaleMode = AutoScaleMode.Dpi;
            CancelButton = btnClose;
            ClientSize = new Size(1198, 867);
            Controls.Add(rootLayout);
            Margin = new Padding(72, 30, 72, 30);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(1224, 938);
            Name = "AdvancedInformationForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Advanced Information";
            rootLayout.ResumeLayout(false);
            pnlFooter.ResumeLayout(false);
            pnlDetail.ResumeLayout(false);
            pnlDetail.PerformLayout();
            pnlMessage.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel rootLayout;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnClose;
        private Panel pnlDetail;
        private TextBox txtDetails;
        private Label lblDetails;
        private Panel pnlMessage;
        private TreeView tvComponents;
        private Label lblMessageComponent;
    }
}
