﻿namespace IDED_Scripting_P1_202010_base.Logic
{
    public class Human : Unit
    {
        public float Potential { get; set; }

        public Human(EUnitClass _unitClass, int _atk, int _def, int _spd, int _moveRange, float _potential)
            : base(_unitClass, _atk, _def, _spd, _moveRange)
        {
            Potential = Clamp(_potential, 0, 10);

            if (UnitClass == EUnitClass.Dragon || UnitClass == EUnitClass.Imp || UnitClass == EUnitClass.Orc)
            {
                UnitClass = EUnitClass.Villager;
                AssignStats();
            }

            AddPotential();
        }

        /// <summary>
        /// Changes unit's UnitClass (if change between classes is allowed).
        /// </summary>
        /// <param name="newClass"></param>
        /// <returns></returns>
        public virtual bool ChangeClass(EUnitClass newClass)
        {
            bool resultado = false;

            if (newClass != UnitClass)
            { 
                switch (UnitClass)
                {
                    case EUnitClass.Villager:
                        resultado = false;
                        break;

                    case EUnitClass.Soldier:
                        if (newClass == EUnitClass.Squire) resultado = true;
                        break;

                    case EUnitClass.Squire:
                        if (newClass == EUnitClass.Soldier) resultado = true;
                        break;

                    case EUnitClass.Mage:
                        if (newClass == EUnitClass.Ranger) resultado = true;
                        break;

                    case EUnitClass.Ranger:
                        if (newClass == EUnitClass.Mage) resultado = true;
                        break;
                }
            }          

            return resultado;
        }

        // Increases Attack and Defense states by a percentage.
        private void AddPotential()
        {
            float a = Attack, d = Defense;

            Attack = a + (a * (Potential / 100));
            Attack = d + (d * (Potential / 100));
        }
    }
}