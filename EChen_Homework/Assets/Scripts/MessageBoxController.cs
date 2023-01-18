using System;
using System.Runtime.InteropServices;

public class MessageBoxController
{
    [DllImport("User32.dll", SetLastError = true, ThrowOnUnmappableChar = true, CharSet = CharSet.Auto)]
    private static extern int MessageBox(IntPtr handle, string message, string title, int type);

    public static int ShowMessageBox(string message, string title, MessageBoxRetrunNumber messageBox)
    {
        return MessageBox(IntPtr.Zero, message, title, (int)messageBox);    
    }      
}

public enum MessageBoxRetrunNumber
{
    OK,
    OKNo,
    AbortRetryIgnore,
    YesNoCancel,
}

public enum MessageResult
{
    None,
    OK,
    Cancel,
    Abort,
    Retry,
    Ignore,
    Yes,
    No
}


