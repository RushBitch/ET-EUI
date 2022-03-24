namespace ET
{
    public class CountDownComponent:Entity,IAwake, IDestroy
    {
        public int count;
        public int additionCount;
        public long countDownTimer;
    }
}