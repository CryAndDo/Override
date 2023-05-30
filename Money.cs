using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Override
{
    internal class Money
    {
        private long rubles;
        private byte kopeks;

        public Money(long rubles, byte kopeks)
        {
            this.rubles = rubles;
            this.kopeks = kopeks;
        }

        public void RoundKopeks()
        {
            rubles += kopeks / 100;
            kopeks = (byte)(kopeks % 100);
        }

        public override string ToString()
        {
            RoundKopeks();
            return string.Format("{0},{1:D2}", rubles, kopeks);
        }

        public static Money operator +(Money m1, Money m2)
        {
            long totalRubles = m1.rubles + m2.rubles;
            byte totalKopeks = (byte)(m1.kopeks + m2.kopeks);

            if (totalKopeks >= 100)
            {
                totalRubles++;
                totalKopeks -= 100;
            }

            return new Money(totalRubles, totalKopeks);
        }

        public static Money operator -(Money m1, Money m2)
        {
            long totalRubles = m1.rubles - m2.rubles;
            byte totalKopeks = (byte)(m1.kopeks - m2.kopeks);

            if (totalKopeks < 0)
            {
                totalRubles--;
                totalKopeks += 100;
            }

            return new Money(totalRubles, totalKopeks);
        }

        public static Money operator *(Money m, double d)
        {
            double totalKopeks = m.rubles * 100 + m.kopeks;
            totalKopeks *= d;

            long newRubles = (long)(totalKopeks / 100);
            byte newKopeks = (byte)(totalKopeks % 100);

            return new Money(newRubles, newKopeks);
        }

        public static Money operator /(Money m, double d)
        {
            double totalKopeks = m.rubles * 100 + m.kopeks;
            totalKopeks /= d;

            long newRubles = (long)(totalKopeks / 100);
            byte newKopeks = (byte)(totalKopeks % 100);

            return new Money(newRubles, newKopeks);
        }

        public static Money operator /(Money m1, Money m2)
        {
            double totalM1 = m1.rubles * 100 + m1.kopeks;
            double totalM2 = m2.rubles * 100 + m2.kopeks;

            double total = totalM1 / totalM2;

            long newRubles = (long)(total / 100);
            byte newKopeks = (byte)(total % 100);

            return new Money(newRubles, newKopeks);
        }

        public static bool operator ==(Money m1, Money m2)
        {
            return m1.rubles == m2.rubles && m1.kopeks == m2.kopeks;
        }

        public static bool operator !=(Money m1, Money m2)
        {
            return m1.rubles != m2.rubles || m1.kopeks != m2.kopeks;
        }

        public static bool operator >(Money m1, Money m2)
        {
            return m1.rubles > m2.rubles || (m1.rubles == m2.rubles && m1.kopeks > m2.kopeks);
        }

        public static bool operator <(Money m1, Money m2)
        {
            return m1.rubles < m2.rubles || (m1.rubles == m2.rubles && m1.kopeks < m2.kopeks);
        }

        public static bool operator >=(Money m1, Money m2)
        {
            return m1.rubles > m2.rubles || (m1.rubles == m2.rubles && m1.kopeks >= m2.kopeks);
        }

        public static bool operator <=(Money m1, Money m2)
        {
            return m1.rubles < m2.rubles || (m1.rubles == m2.rubles && m1.kopeks <= m2.kopeks);
        }
    }
}
