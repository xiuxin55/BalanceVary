﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Server
{
    public class CommonEvent
    {
        public static Action<object> FileUploadedCalculateEvent;
        public static Action<object> FileUploadedCalculateDayEvent;
        public static Action<object> FileUploadedCustomerLinkEvent;
    }
}
