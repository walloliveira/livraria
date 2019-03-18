namespace LivrariaAPI.Domain
{
    public class NullDomain
    {
        private NullDomain() { }

        public static NullDomain GetInstance()
        {
            return new NullDomain();
        }
    }
}
