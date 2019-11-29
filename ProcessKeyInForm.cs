protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
  {
      if (keyData == Keys.F8)
      {
          button1.PerformClick();
      }

      return base.ProcessCmdKey(ref msg, keyData);
  }
