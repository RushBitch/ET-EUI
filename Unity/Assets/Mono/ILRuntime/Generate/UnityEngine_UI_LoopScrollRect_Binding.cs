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
    unsafe class UnityEngine_UI_LoopScrollRect_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            FieldInfo field;
            Type[] args;
            Type type = typeof(UnityEngine.UI.LoopScrollRect);
            args = new Type[]{typeof(System.Action<UnityEngine.Transform, System.Int32>)};
            method = type.GetMethod("AddItemRefreshListener", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, AddItemRefreshListener_0);
            args = new Type[]{typeof(System.Int32), typeof(System.Boolean)};
            method = type.GetMethod("RefillCells", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, RefillCells_1);

            field = type.GetField("totalCount", flag);
            app.RegisterCLRFieldGetter(field, get_totalCount_0);
            app.RegisterCLRFieldSetter(field, set_totalCount_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_totalCount_0, AssignFromStack_totalCount_0);


        }


        static StackObject* AddItemRefreshListener_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Action<UnityEngine.Transform, System.Int32> @scrollMoveEvent = (System.Action<UnityEngine.Transform, System.Int32>)typeof(System.Action<UnityEngine.Transform, System.Int32>).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)8);
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            UnityEngine.UI.LoopScrollRect instance_of_this_method = (UnityEngine.UI.LoopScrollRect)typeof(UnityEngine.UI.LoopScrollRect).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.AddItemRefreshListener(@scrollMoveEvent);

            return __ret;
        }

        static StackObject* RefillCells_1(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 3);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Boolean @fillViewRect = ptr_of_this_method->Value == 1;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            System.Int32 @offset = ptr_of_this_method->Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 3);
            UnityEngine.UI.LoopScrollRect instance_of_this_method = (UnityEngine.UI.LoopScrollRect)typeof(UnityEngine.UI.LoopScrollRect).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.RefillCells(@offset, @fillViewRect);

            return __ret;
        }


        static object get_totalCount_0(ref object o)
        {
            return ((UnityEngine.UI.LoopScrollRect)o).totalCount;
        }

        static StackObject* CopyToStack_totalCount_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((UnityEngine.UI.LoopScrollRect)o).totalCount;
            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static void set_totalCount_0(ref object o, object v)
        {
            ((UnityEngine.UI.LoopScrollRect)o).totalCount = (System.Int32)v;
        }

        static StackObject* AssignFromStack_totalCount_0(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Int32 @totalCount = ptr_of_this_method->Value;
            ((UnityEngine.UI.LoopScrollRect)o).totalCount = @totalCount;
            return ptr_of_this_method;
        }



    }
}
