using System;
using System.Collections.Generic;
using System.Text;

namespace bbs.AppTemplate.Models
{
    public class APIEventArgs : EventArgs
    {
        public string JsonResponse { get; private set; }
        
    }
}
