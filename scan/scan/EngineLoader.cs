// ?2013 ABBYY Production LLC
// SAMPLES code is property of ABBYY, exclusive rights are reserved. 
//
// DEVELOPER is allowed to incorporate SAMPLES into his own APPLICATION and modify it under 
// the  terms of  License Agreement between  ABBYY and DEVELOPER.


// ABBYY FineReader Engine 11 Sample

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Configuration;
using System.Runtime.InteropServices;
using FREngine;
using scan.Util;

namespace Sample
{
    // Class for loading/unloading FREngine.dll and initializing/deinitializing Engine.
    // Loading is performed in constructor, unloading in Dispose()
    // Throws exceptions when loading fails
    public class EngineLoader : IDisposable
    {
        // Load FineReader Engine with settings stored in SamplesConfig.cs
        public EngineLoader()
        {            
            string sdkPath = ConfigurationManager.AppSettings["sdkPath"];
            string developerSN = Util.GetDecryptedValue(Util.GetAppSetting("sn"));

         

            string enginePath = Path.Combine(sdkPath, "FREngine.dll");
         


            // Load the FREngine.dll library
            dllHandle = LoadLibraryEx(enginePath, IntPtr.Zero, LOAD_WITH_ALTERED_SEARCH_PATH);
            
            try
            {
                if (dllHandle == IntPtr.Zero)
                {
                    throw new Exception("不能加载 " + enginePath);
                }

                IntPtr getEngineObjectPtr = GetProcAddress(dllHandle, "GetEngineObject");
                if (getEngineObjectPtr == IntPtr.Zero)
                {
                    throw new Exception("没有发现 GetEngineObject 方法");
                }
                IntPtr deinitializeEnginePtr = GetProcAddress(dllHandle, "DeinitializeEngine");
                if (deinitializeEnginePtr == IntPtr.Zero)
                {
                    throw new Exception("没有发现 DeinitializeEngine 方法");
                }
                IntPtr dllCanUnloadNowPtr = GetProcAddress(dllHandle, "DllCanUnloadNow");
                if (dllCanUnloadNowPtr == IntPtr.Zero)
                {
                    throw new Exception("没有发现 DllCanUnloadNow 方法");
                }

                // Convert pointers to delegates
                getEngineObject = (GetEngineObject)Marshal.GetDelegateForFunctionPointer(
                    getEngineObjectPtr, typeof(GetEngineObject));
                deinitializeEngine = (DeinitializeEngine)Marshal.GetDelegateForFunctionPointer(
                    deinitializeEnginePtr, typeof(DeinitializeEngine));
                dllCanUnloadNow = (DllCanUnloadNow)Marshal.GetDelegateForFunctionPointer(
                    dllCanUnloadNowPtr, typeof(DllCanUnloadNow));

                // Call the GetEngineObject function
                int hresult = getEngineObject(developerSN, ref engine);

                Marshal.ThrowExceptionForHR(hresult);
            }
            catch (Exception)
            {
                // Free the FREngine.dll library
                engine = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                FreeLibrary(dllHandle);
                dllHandle = IntPtr.Zero;
                getEngineObject = null;
                deinitializeEngine = null;
                dllCanUnloadNow = null;

                throw;
            } 
        }

        // Unload FineReader Engine
        public void Dispose()
        {
            if (engine == null)
            {
                // Engine was not loaded
                return;
            }

            engine = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            int hresult = deinitializeEngine();

            hresult = dllCanUnloadNow();
            if (hresult == 0)
            {
                FreeLibrary(dllHandle);
            }
            dllHandle = IntPtr.Zero;
            getEngineObject = null;
            deinitializeEngine = null;
            dllCanUnloadNow = null;

            // thowing exception after cleaning up
            Marshal.ThrowExceptionForHR(hresult);
        }

        // Returns pointer to FineReader Engine's main object
        public IEngine Engine
        {
            get
            {
                return engine;
            }
        }
        

        // Kernel32.dll functions
        [DllImport("kernel32.dll")]
        private static extern IntPtr LoadLibraryEx(string dllToLoad, IntPtr reserved, uint flags);
        private const uint LOAD_WITH_ALTERED_SEARCH_PATH = 0x00000008;
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);
        [DllImport("kernel32.dll")]
        private static extern bool FreeLibrary(IntPtr hModule);

        // FREngine.dll functions
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private delegate int GetEngineObject(string devSN, ref FREngine.IEngine engine);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate int DeinitializeEngine();

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate int DllCanUnloadNow();

        // private variables
        private FREngine.IEngine engine = null;
        // Handle to FREngine.dll
        private IntPtr dllHandle = IntPtr.Zero;

        private GetEngineObject getEngineObject = null;
        private DeinitializeEngine deinitializeEngine = null;
        private DllCanUnloadNow dllCanUnloadNow = null;
    }
}
