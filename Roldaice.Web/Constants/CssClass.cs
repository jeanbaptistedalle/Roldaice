﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Roldaice.Web.Constants
{
    public class CssClass
    {
        public const string DataTables = "js-apply-data-table";
        public const string Slider = "js-input-slider";
        public const string DatePicker = "js-datepicker";
        public const string DayMonthPicker = "js-day-month-picker";
        public const string YearPicker = "js-year-picker";
        public const string Select = "js-select-picker";
        public const string DataToggle = "js-datatoggle";
        public const string Identicon = "js-identicon";

        public const string AppIcon = "app-icon";


        public class FontAwesome
        {
            public const string Base = "fa fa-";
            public const string BaseFixedWidth = "fa-fw " + Base;
            public const string BaseBigIcon = "fa-3x " + BaseFixedWidth;

            public const string Configuration = BaseFixedWidth + "cogs";
            public const string Profile = BaseFixedWidth + "user-circle";
            public const string Submit = BaseFixedWidth + "check";

            public const string User = BaseFixedWidth + "id-badge";
            public const string Login = BaseFixedWidth + "sign-in";
            public const string Logout = BaseFixedWidth + "sign-out";
            public const string SeePassword = BaseFixedWidth + "eye-slash";

            public const string RollDiceAppIcon = BaseBigIcon + "cog";
            public const string EnigmaAppIcon = BaseBigIcon + "lock";
            public const string TestAppIcon = BaseBigIcon + "flask";
            public const string ProfileAppIcon = BaseBigIcon + "user-circle";
            public const string LoginAppIcon = BaseBigIcon + "sign-in";
            public const string LogoutAppIcon = BaseBigIcon + "sign-out";
        }
    }
}