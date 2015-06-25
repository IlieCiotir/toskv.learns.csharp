using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Security.Permissions;
using System.Runtime.InteropServices;

// Had to enable legacy security support in App.config for this to work the tutorial does not specify this
namespace Security
{
    class NativeMethods
    {
        // This is a call to unmanaged code. Executing this method requires 
        // the UnmanagedCode security permission. Without this permission
        // an attempt to call this method will throw a SecurityException:
        [DllImport("msvcrt.dll")]
        public static extern int puts(string str);
        [DllImport("msvcrt.dll")]
        internal static extern int _flushall();
    }

    class Imperative
    {
        private static void CallMethodsWithoutPermissions()
        {
            SecurityPermission perm = new SecurityPermission(SecurityPermissionFlag.UnmanagedCode);
            // Deny is deprecated, comment doesn't specify what is replaced by
            perm.Deny();

            try
            {
                Console.WriteLine("Trying to call unmanaged code without permissions");
                NativeMethods.puts("I'm unsecure!");
                NativeMethods._flushall();
                Console.WriteLine("Success! I'm a hacker!");
            }
            catch (SecurityException e)
            {
                Console.WriteLine("Gotcha!" + e);
            }
        }

        private static void CallMethodsWithPermission()
        {
            SecurityPermission perm = new SecurityPermission(SecurityPermissionFlag.UnmanagedCode);
            perm.Assert();

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
