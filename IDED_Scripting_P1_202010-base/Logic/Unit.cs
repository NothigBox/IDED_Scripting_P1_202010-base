namespace IDED_Scripting_P1_202010_base.Logic
{
    public class Unit
    {
        public const int VALOR_MAX = 255;
        public const int VALOR_MIN = 0;

        public int BaseAtk { get; protected set; }
        public int BaseDef { get; protected set; }
        public int BaseSpd { get; protected set; }

        public int MoveRange { get; protected set; }
        public int AtkRange { get; protected set; }

        public float BaseAtkAdd { get; protected set; }
        public float BaseDefAdd { get; protected set; }
        public float BaseSpdAdd { get; protected set; }

        public float Attack { get; }
        public float Defense { get; }
        public float Speed { get; }

        protected Position CurrentPosition;

        public EUnitClass UnitClass { get; protected set; }

        public Unit(EUnitClass _unitClass, int _atk, int _def, int _spd, int _moveRange)
        {
            UnitClass = _unitClass;
            BaseAtk = _atk;
            BaseDef = _def;
            BaseSpd = _spd;
            MoveRange = _moveRange;
        }

        public void BaseAdds()
        {
            switch (UnitClass)
            {
                case EUnitClass.Dragon:
                    BaseAtkAdd = 5 / 100;
                    BaseDefAdd = 3 / 100;
                    BaseSpdAdd = 2 / 100;
                    break;
                case EUnitClass.Imp:
                    BaseAtkAdd = 1 / 100;
                    BaseDefAdd = 0 / 100;
                    BaseSpdAdd = 0 / 100;
                    break;
                case EUnitClass.Mage:
                    BaseAtkAdd = 3 / 100;
                    BaseDefAdd = 1 / 100;
                    BaseSpdAdd = -1 / 100;
                    break;
                case EUnitClass.Orc:
                    BaseAtkAdd = 4 / 100;
                    BaseDefAdd = 2 / 100;
                    BaseSpdAdd = -2 / 100;
                    break;
                case EUnitClass.Ranger:
                    BaseAtkAdd = 1 / 100;
                    BaseDefAdd = 0 / 100;
                    BaseSpdAdd = 3 / 100;
                    break;
                case EUnitClass.Soldier:
                    BaseAtkAdd = 3 / 100;
                    BaseDefAdd = 2 / 100;
                    BaseSpdAdd = 1 / 100;
                    break;
                case EUnitClass.Squire:
                    BaseAtkAdd = 2 / 100;
                    BaseDefAdd = 1 / 100;
                    BaseSpdAdd = 0 / 100;
                    break;
                case EUnitClass.Villager:
                    BaseAtkAdd = 0 / 100;
                    BaseDefAdd = 0 / 100;
                    BaseSpdAdd = 0 / 100;
                    break;
            }
            

            BaseAtk = Clamp(BaseAtk + BaseAtkAdd *BaseAtk);
            BaseDef = Clamp(BaseDef + BaseDefAdd * BaseDef);
            BaseSpd = Clamp(BaseSpd + BaseSpdAdd * BaseSpd);
        }

        public virtual bool Interact(Unit otherUnit)
        {
            return false;
        }

        public virtual bool Interact(Prop prop)
        {
            if (UnitClass == EUnitClass.Villager) return true;
            else return false;
        }

        public bool Move(Position targetPosition) => false;

        public int Clamp(float val)
        {
            if (val < VALOR_MIN) return VALOR_MIN;
            else if (val > VALOR_MAX) return VALOR_MAX;
            else return (int)val;
        }
    }
}