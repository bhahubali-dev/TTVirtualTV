﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace VirtualEvent.iOS
{
    class HomeTableClass : UITableViewSource
    {
        private string CellIdentifier = "cellId";
        UITableView tableView;
        NSIndexPath indexPath;
       // UIView CellView;

        public HomeTableClass()
        {
           
        }
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            this.tableView = tableView;
            this.indexPath = indexPath;
          
            UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier, indexPath);

            if (cell == null)
            { cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier); }
            //CellView = cell.ViewWithTag(1) as UIView;
            tableView.SeparatorColor = UIColor.White;
           // CellView.Layer.BorderColor = UIColor.Gray.CGColor;
           // CellView.Layer.BorderWidth = 3f;
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return 10;
        }
        public override nint NumberOfSections(UITableView tableView)
        {
            return 1;
        }
        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return 133.0f;
        }
    }
}