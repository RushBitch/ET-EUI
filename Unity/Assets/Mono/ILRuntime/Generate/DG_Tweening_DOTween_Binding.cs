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
    unsafe class DG_Tweening_DOTween_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            Type[] args;
            Type type = typeof(DG.Tweening.DOTween);
            args = new Type[]{typeof(System.Int32), typeof(System.Int32)};
            method = type.GetMethod("SetTweensCapacity", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, SetTweensCapacity_0);
            args = new Type[]{};
            method = type.GetMethod("Sequence", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, Sequence_1);


        }


        static StackObject* SetTweensCapacity_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Int32 @sequencesCapacity = ptr_of_this_method->Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            System.Int32 @tweenersCapacity = ptr_of_this_method->Value;


            DG.Tweening.DOTween.SetTweensCapacity(@tweenersCapacity, @sequencesCapacity);

            return __ret;
        }

        static StackObject* Sequence_1(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);


            var result_of_this_method = DG.Tweening.DOTween.Sequence();

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }



    }
}
