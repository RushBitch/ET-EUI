namespace ET
{
    public class CountDownComponent:Entity,IAwake, IDestroy
    {
        public int count;
        public static int additionCount;
        public long countDownTimer;
    }
}