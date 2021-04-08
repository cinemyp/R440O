using R440O.LearnModule;

namespace R440O.BaseClasses
{
    public interface IBaseModule
    {
        void SetIntent(ModulesEnum module);
        ModulesEnum GetIntent();
        void Action();

    }
}
