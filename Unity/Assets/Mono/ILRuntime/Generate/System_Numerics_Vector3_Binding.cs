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
    unsafe class System_Numerics_Vector3_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            FieldInfo field;
            Type[] args;
            Type type = typeof(System.Numerics.Vector3);

            field = type.GetField("X", flag);
            app.RegisterCLRFieldGetter(field, get_X_0);
            app.RegisterCLRFieldSetter(field, set_X_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_X_0, AssignFromStack_X_0);
            field = type.GetField("Y", flag);
            app.RegisterCLRFieldGetter(field, get_Y_1);
            app.RegisterCLRFieldSetter(field, set_Y_1);
            app.RegisterCLRFieldBinding(field, CopyToStack_Y_1, AssignFromStack_Y_1);
            field = type.GetField("Z", flag);
            app.RegisterCLRFieldGetter(field, get_Z_2);
            app.RegisterCLRFieldSetter(field, set_Z_2);
            app.RegisterCLRFieldBinding(field, CopyToStack_Z_2, AssignFromStack_Z_2);

            app.RegisterCLRCreateDefaultInstance(type, () => new System.Numerics.Vector3());

            args = new Type[]{typeof(System.Single), typeof(System.Single), typeof(System.Single)};
            method = type.GetConstructor(flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, Ctor_0);

        }

        static void WriteBackInstance(ILRuntime.Runtime.Enviorment.AppDomain __domain, StackObject* ptr_of_this_method, IList<object> __mStack, ref System.Numerics.Vector3 instance_of_this_method)
        {
            ptr_of_this_method = ILIntepreter.GetObjectAndResolveReference(ptr_of_this_method);
            switch(ptr_of_this_method->ObjectType)
            {
                case ObjectTypes.Object:
                    {
                        __mStack[ptr_of_this_method->Value] = instance_of_this_method;
                    }
                    break;
                case ObjectTypes.FieldReference:
                    {
                        var ___obj = __mStack[ptr_of_this_method->Value];
                        if(___obj is ILTypeInstance)
                        {
                            ((ILTypeInstance)___obj)[ptr_of_this_method->ValueLow] = instance_of_this_method;
                        }
                        else
                        {
                            var t = __domain.GetType(___obj.GetType()) as CLRType;
                            t.SetFieldValue(ptr_of_this_method->ValueLow, ref ___obj, instance_of_this_method);
                        }
                    }
                    break;
                case ObjectTypes.StaticFieldReference:
                    {
                        var t = __domain.GetType(ptr_of_this_method->Value);
                        if(t is ILType)
                        {
                            ((ILType)t).StaticInstance[ptr_of_this_method->ValueLow] = instance_of_this_method;
                        }
                        else
                        {
                            ((CLRType)t).SetStaticFieldValue(ptr_of_this_method->ValueLow, instance_of_this_method);
                        }
                    }
                    break;
                 case ObjectTypes.ArrayReference:
                    {
                        var instance_of_arrayReference = __mStack[ptr_of_this_method->Value] as System.Numerics.Vector3[];
                        instance_of_arrayReference[ptr_of_this_method->ValueLow] = instance_of_this_method;
                    }
                    break;
            }
        }


        static object get_X_0(ref object o)
        {
            return ((System.Numerics.Vector3)o).X;
        }

        static StackObject* CopyToStack_X_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((System.Numerics.Vector3)o).X;
            __ret->ObjectType = ObjectTypes.Float;
            *(float*)&__ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static void set_X_0(ref object o, object v)
        {
            System.Numerics.Vector3 ins =(System.Numerics.Vector3)o;
            ins.X = (System.Single)v;
            o = ins;
        }

        static StackObject* AssignFromStack_X_0(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Single @X = *(float*)&ptr_of_this_method->Value;
            System.Numerics.Vector3 ins =(System.Numerics.Vector3)o;
            ins.X = @X;
            o = ins;
            return ptr_of_this_method;
        }

        static object get_Y_1(ref object o)
        {
            return ((System.Numerics.Vector3)o).Y;
        }

        static StackObject* CopyToStack_Y_1(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((System.Numerics.Vector3)o).Y;
            __ret->ObjectType = ObjectTypes.Float;
            *(float*)&__ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static void set_Y_1(ref object o, object v)
        {
            System.Numerics.Vector3 ins =(System.Numerics.Vector3)o;
            ins.Y = (System.Single)v;
            o = ins;
        }

        static StackObject* AssignFromStack_Y_1(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Single @Y = *(float*)&ptr_of_this_method->Value;
            System.Numerics.Vector3 ins =(System.Numerics.Vector3)o;
            ins.Y = @Y;
            o = ins;
            return ptr_of_this_method;
        }

        static object get_Z_2(ref object o)
        {
            return ((System.Numerics.Vector3)o).Z;
        }

        static StackObject* CopyToStack_Z_2(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((System.Numerics.Vector3)o).Z;
            __ret->ObjectType = ObjectTypes.Float;
            *(float*)&__ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static void set_Z_2(ref object o, object v)
        {
            System.Numerics.Vector3 ins =(System.Numerics.Vector3)o;
            ins.Z = (System.Single)v;
            o = ins;
        }

        static StackObject* AssignFromStack_Z_2(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Single @Z = *(float*)&ptr_of_this_method->Value;
            System.Numerics.Vector3 ins =(System.Numerics.Vector3)o;
            ins.Z = @Z;
            o = ins;
            return ptr_of_this_method;
        }


        static StackObject* Ctor_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 3);
            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Single @z = *(float*)&ptr_of_this_method->Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            System.Single @y = *(float*)&ptr_of_this_method->Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 3);
            System.Single @x = *(float*)&ptr_of_this_method->Value;


            var result_of_this_method = new System.Numerics.Vector3(@x, @y, @z);

            if(!isNewObj)
            {
                __ret--;
                WriteBackInstance(__domain, __ret, __mStack, ref result_of_this_method);
                return __ret;
            }

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }


    }
}
