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
    unsafe class ET_GameConfig_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            FieldInfo field;
            Type[] args;
            Type type = typeof(ET.GameConfig);

            field = type.GetField("GameMode", flag);
            app.RegisterCLRFieldGetter(field, get_GameMode_0);
            app.RegisterCLRFieldSetter(field, set_GameMode_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_GameMode_0, AssignFromStack_GameMode_0);
            field = type.GetField("GameView", flag);
            app.RegisterCLRFieldGetter(field, get_GameView_1);
            app.RegisterCLRFieldSetter(field, set_GameView_1);
            app.RegisterCLRFieldBinding(field, CopyToStack_GameView_1, AssignFromStack_GameView_1);


        }



        static object get_GameMode_0(ref object o)
        {
            return ET.GameConfig.GameMode;
        }

        static StackObject* CopyToStack_GameMode_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ET.GameConfig.GameMode;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_GameMode_0(ref object o, object v)
        {
            ET.GameConfig.GameMode = (ET.GameMode)v;
        }

        static StackObject* AssignFromStack_GameMode_0(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            ET.GameMode @GameMode = (ET.GameMode)typeof(ET.GameMode).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)20);
            ET.GameConfig.GameMode = @GameMode;
            return ptr_of_this_method;
        }

        static object get_GameView_1(ref object o)
        {
            return ET.GameConfig.GameView;
        }

        static StackObject* CopyToStack_GameView_1(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ET.GameConfig.GameView;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_GameView_1(ref object o, object v)
        {
            ET.GameConfig.GameView = (ET.GameView)v;
        }

        static StackObject* AssignFromStack_GameView_1(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            ET.GameView @GameView = (ET.GameView)typeof(ET.GameView).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)20);
            ET.GameConfig.GameView = @GameView;
            return ptr_of_this_method;
        }



    }
}
