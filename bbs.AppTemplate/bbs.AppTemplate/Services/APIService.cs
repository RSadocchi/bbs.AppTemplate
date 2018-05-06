using bbs.AppTemplate.Globals;
using bbs.AppTemplate.Interfaces;
using bbs.AppTemplate.Models;
using bbs.AppTemplate.Views;
using bbs.AppTemplate.Resources.Langs;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace bbs.AppTemplate.Services
{
    public class APIService : IDisposable
    {
        #region PRIVATE FIELDS
        WebClient _client;
        string _baseUrl;
        APIException _exception;
        #endregion



        #region PUBLIC FIELDS
        public string BaseUrl { get { return _baseUrl; } set { _baseUrl = value; } }
        public APIException GetException { get { return _exception; } }
        #endregion



        #region CONSTRUCTORS
        public APIService(string baseUrl)
        {
            _client = new WebClient();
            _baseUrl = baseUrl;
        }
        #endregion



        #region PRIVATE METHODS
        bool _checkBaseUrl() { return (!string.IsNullOrEmpty(_baseUrl) || !string.IsNullOrWhiteSpace(_baseUrl)); }
        #endregion



        #region PUBLIC METHODS
        
        #endregion



        #region EVENT HANDLER
        public delegate void RequestCompleteHandler(object sender, EventArgs args);
        public event RequestCompleteHandler RequestComplete;
        protected virtual void OnRequestComplete(EventArgs args) { RequestComplete?.Invoke(this, args); }
        #endregion



        #region Disposable
        bool _disposed;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;
            if (disposing && _client != null)
            {
                _client.Dispose();
            }
            _disposed = true;
        }

        #endregion
    }
}
