using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

using ILRuntime.CLR.TypeSystem;
using ILRuntime.CLR.Method;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;
using ILRuntime.Runtime.Stack;
using ILRuntime.Reflection;
using ILRuntime.CLR.Utils;

namespace ILRuntime.Runtime.Generated
{
    unsafe class ET_MulitLanguageText_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            FieldInfo field;
            Type[] args;
            Type type = typeof(ET.MulitLanguageText);

            field = type.GetField("SetText", flag);
            app.RegisterCLRFieldGetter(field, get_SetText_0);
            app.RegisterCLRFieldSetter(field, set_SetText_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_SetText_0, AssignFromStack_SetText_0);


        }



        static object get_SetText_0(ref object o)
        {
            return ET.MulitLanguageText.SetText;
        }

        static StackObject* CopyToStack_SetText_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ET.MulitLanguageText.SetText;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_SetText_0(ref object o, object v)
        {
            ET.MulitLanguageText.SetText = (System.Action<UnityEngine.UI.Text, System.Int32>)v;
        }

        static StackObject* AssignFromStack_SetText_0(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Action<UnityEngine.UI.Text, System.Int32> @SetText = (System.Action<UnityEngine.UI.Text, System.Int32>)typeof(System.Action<UnityEngine.UI.Text, System.Int32>).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)8);
            ET.MulitLanguageText.SetText = @SetText;
            return ptr_of_this_method;
        }



    }
}
