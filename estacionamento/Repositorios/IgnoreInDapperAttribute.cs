namespace estacionamento.Repositorios
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    sealed class IgnoreInDapperAttribute : Attribute
    {
        public IgnoreInDapperAttribute(){}
        
    }
}