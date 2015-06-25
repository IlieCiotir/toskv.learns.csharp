using System;
using System.Security;
using System.Security.Permissions;
using System.Runtime.InteropServices;

namespace Security
{
    class NativeFastCalls
    {
        // This is a call to unmanaged code. Executing this method requires 
        // the UnmanagedCode security permission. Without this permission,
        // an attempt to call this method will throw a SecurityException:
        [SuppressUnmanagedCodeSecurity()]
        [DllImport("msvcrt.dll")]
        public static extern int puts(string str);

        [SuppressUnmanagedCodeSecurity()]
        [DllImport("msvcrt.dll")]
        internal static extern int _flushall();
    }

    class Performance
    {   
        // Still deprecated
        [SecurityPermission(SecurityAction.Deny, Flags =SecurityPermissionFlag.UnmanagedCode)]
        private static void CallMethodsWithoutPermissions()
        {
            try
            {
                // Since unmanaged code permission is no longer respected by the fast calls we need another permission to check
                UIPermission uiPermission = new UIPermission(PermissionState.Unrestricted);
                uiPermission.Demand();

                Console.WriteLine("Trying to call unmanaged code without permissions");
                NativeFastCalls.puts("I'm unsecure!");
                NativeFastCalls._flushall();
                Console.WriteLine("Success! I'm a hacker!");
            }
            catch (SecurityException e)
            {
                Console.WriteLine("Gotcha!");
            }
        }

        [SecurityPermission(SecurityAction.Assert, Flags=SecurityPermissionFlag.UnmanagedCode)]
        private static void CallMethodsWithPermission()
        {
            try
            {
                Console.WriteLine("Trying to call unmanaged code with permissions");
                NativeMethods.puts("I should work just fine.");
                NativeMethods._flushall();
                Console.WriteLine("Success! Everything works as expected.");
            }
            catch (SecurityException e)
            {
                Console.WriteLine("Something went terribly bad" + e);
            }
        }
        static void Main(string[] args)
        {
            SecurityPermission perm = new SecurityPermission(SecurityPermissionFlag.UnmanagedCode);
            // Make sure we have the permission so we can deny it later
            perm.Assert();
            CallMethodsWithoutPermissions();

            // Deny the permissions so we can ask for it later
            perm.Deny();
            CallMethodsWithPermission();
        }
    }
}
