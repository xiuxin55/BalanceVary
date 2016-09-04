<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="JqGridDemoWebForm.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" ></>
<head>
    <title></title>
    <link rel="Stylesheet" href="Styles/jquery.ui.css" type="text/css" />
    <link rel="Stylesheet" href="Styles/jquery.jqgrid.css" type="text/css" />
    <script src="Scripts/jquery.js" type="text/javascript"></script>
    <script src="Scripts/jquery.ui.js" type="text/javascript"></script>
    <script src="Scripts/i18n/grid.locale-cn.js" type="text/javascript"></script>
    <script src="Scripts/jquery.jqgrid.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $('#list').jqGrid({
                url: 'SvcDept.ashx',
                ajaxGridOptions: { contentType: 'application/json; charset=utf-8' },
                datatype: 'json',
                mtype: 'Get',
                treeGrid: true,
                treeGridModel: 'adjacency',
                ExpandColumn: 'Name',
                colNames: ['ID', '网点编号', '名称/账号', '网点/公司/子账号', '定期余额', '活期余额', '总余额','网点地址','网点电话' ,'网点经理','网点经理电话','时间','ParentID'],
                colModel: [
                { name: 'ID', index: 'ID', hidden: true, width: 1, key: true },
                { name: 'WebsiteID', index: 'WebsiteID',  hidden: true },
                { name: 'Name', index: 'Name', width: 300 },
                { name: 'DifferWebsite', index: 'DifferWebsite', width: 180 },
                { name: 'RegularMoney', index: 'RegularMoney', key: true },
                { name: 'UnRegularMoney', index: 'UnRegularMoney' },
                { name: 'AmountMoney', index: 'AmountMoney' },
                { name: 'WebsiteAddress', index: 'WebsiteAddress' },
                { name: 'WebsiteTel', index: 'WebsiteTel' },
                { name: 'WebsiteManager', index: 'WebsiteManager' },
                { name: 'ManagerTelphone', index: 'ManagerTelphone' },
                { name: 'BalanceTime', index: 'BalanceTime' },
                { name: 'ParentID', index: 'ParentID', hidden: true, width: 1 }
                ],
      
               rownumbers: false,
//                autowidth: true
               width: document.documentElement.clientWidth-23 ,
               height: document.documentElement.clientHeight-55 ,  
               autowidth: false,
              shrinkToFit: true
//                //                width:'auto',
           
//                height: 'auto'
            });
        });
    </script>
</head>
<body style="overflow:auto;">
    <table id="list">
    </table>
    </body>
</html>
