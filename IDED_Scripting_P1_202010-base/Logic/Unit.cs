namespace IDED_Scripting_P1_202010_base.Logic
{
    public class Unit
    {
        public int BaseAtk { get; protected set; }
        public int BaseDef { get; protected set; }
        public int BaseSpd { get; protected set; }

        public int MoveRange { get; protected set; }
        public int AtkRange { get; protected set; }

        public float BaseAtkAdd { get; protected set; }
        public float BaseDefAdd { get; protected set; }
        public float BaseSpdAdd { get; protected set; }

        public float Attack { get; protected set; }
        public float Defense { get; protected set; }
        public float Speed { get; protected set; }

        protected Position CurrentPosition;

        public EUnitClass UnitClass { get; protected set; }

        public Unit(EUnitClass _unitClass, int _atk, int _def, int _spd, int _moveRange)
        {
            UnitClass = _unitClass;
            BaseAtk = _atk;
            BaseDef = _def;
            BaseSpd = _spd;
            MoveRange = (int)Clamp(_moveRange, 0, 10);

            CurrentPosition = new Position(0);

            AssignStats();
        }

        /// <summary>
        /// Check if interaction with other unit is possible.
        /// </summary>
        /// <param name="otherUnit"></param>
        /// <returns></returns>
        public virtual bool Interact(Unit otherUnit)
        {
            bool isInteractable = true;

            switch(UnitClass)
            {
                case EUnitClass.Dragon:
                    isInteractable = true;
                    break;

                case EUnitClass.Imp:
                    if (otherUnit.UnitClass == EUnitClass.Dragon) isInteractable = false;
                    break;

                case EUnitClass.Mage:
                    if (otherUnit.UnitClass == EUnitClass.Mage) isInteractable = false;
                    break;

                case EUnitClass.Orc:
                    if (otherUnit.UnitClass == EUnitClass.Dragon) isInteractable = false;
                    break;

                case EUnitClass.Ranger:
                    if (otherUnit.UnitClass == EUnitClass.Mage || otherUnit.UnitClass == EUnitClass.Dragon) isInteractable = false;
                    break;

                case EUnitClass.Soldier:
                    if (otherUnit.UnitClass == EUnitClass.Villager) isInteractable = false;
                    break;

                case EUnitClass.Squire:
                    if (otherUnit.UnitClass == EUnitClass.Villager) isInteractable = false;
                    break;

                case EUnitClass.Villager:
                    isInteractable = false;
                    break;
            }

            if (isInteractable)
            {
                //  Functionality.
            }

            return isInteractable;
        }

        /// <summary>
        /// Check if interaction with a prop is possible.
        /// </summary>
        /// <param name="prop"></param>
        /// <returns></returns>
        public virtual bool Interact(Prop prop)
        {
            bool isVillager = UnitClass == EUnitClass.Villager;

            if (isVillager)
            {
                //  Functionality.
            }

            return isVillager;
        }

        /// <summary>
        /// Changes unit's actual position to a target one (if target is inRange).
        /// </summary>
        /// <param name="targetPosition"></param>
        /// <returns></returns>
        public bool Move(Position targetPosition) 
        {
            bool inRange = targetPosition.x <= MoveRange && targetPosition.y <= MoveRange;

            if (inRange) CurrentPosition = targetPosition;

            return inRange;
        }

        /// <summary>
        /// Assigns unit's final STATS.
        /// </summary>
        protected void AssignStats()
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

            Attack = Clamp(
                BaseAtk + (BaseAtkAdd * BaseAtk),
                0, 255);
            Defense = Clamp(
                BaseDef + (BaseDefAdd * BaseDef),
                0, 255);
            Speed = Clamp(
                BaseSpd + (BaseSpdAdd * BaseSpd),
                0, 255);

            AtkRange = AssignAttackRange();
        }

        /// <summary>
        /// Assigns unit's attack range due its type.
        /// </summary>
        /// <returns></returns>
        protected int AssignAttackRange()
        {
            int range = 0;

            switch (UnitClass)
            {
                case EUnitClass.Dragon: range = 5;
                    break;

                case EUnitClass.Mage: range = 3;
                    break;

                case EUnitClass.Ranger: range = 3;
                    break;

                case EUnitClass.Villager: range = 0;
                    break;

                default: range = 1;
                    break;
            }

            return range;
        }

        /// <summary>
        /// Limits val to a Min & Max.
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        protected float Clamp(float val, float min, float max)
        {
            if (val < min) return min;
            else if (val > max) return max;
            else return val;
        }
    }
}