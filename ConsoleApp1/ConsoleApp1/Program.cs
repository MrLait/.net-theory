﻿using System;

public sealed class BitArray
{
    // Закрытый байтовый массив, хранящий биты
    private Byte[] m_byteArray;
    private Int32 m_numBits;
    // Конструктор, выделяющий память для байтового массива
    // и устанавливающий все биты в 0
    public BitArray(Int32 numBits)
    {
        // Начинаем с проверки аргументов
        if (numBits <= 0)
            throw new ArgumentOutOfRangeException("numBits must be > 0");

        //Сохранить число битов
        m_numBits = numBits;
        // Выделить байты для массива битов
        m_byteArray = new Byte[(numBits + 7) / 8];
    }
    // Индексатор (свойство с параметрами)
    public Boolean this[Int32 bitPos]
    {
        // Метод доступа get индексатора
        get
        {
            // Сначала нужно проверить аргументы
            if (bitPos < 0 || bitPos >= m_numBits)
                throw new ArgumentOutOfRangeException("bitPos");
            // Вернуть состояние индексируемого бита
            return (m_byteArray[bitPos / 8] & (1 << (bitPos % 8))) != 0;
        }
        // Метод доступа set индексатора
        set
        {
            if (bitPos < 0 || bitPos >= m_numBits)
                throw new ArgumentOutOfRangeException(
                    "bitPos", bitPos.ToString());
            if (value)
            {
                // Установить индексируемый бит
                m_byteArray[bitPos / 8] = (Byte)
                    (m_byteArray[bitPos / 8] | (1 << (bitPos % 8)));
            }
            else
            {
                // Сбросить индексируемый бит
                m_byteArray[bitPos / 8] = (Byte)
                    (m_byteArray[bitPos / 8] & ~(1 << (bitPos % 8)));
            }
        }
    }

    public Boolean get_Item(Int32 bitPos)
    {
        if (bitPos < 0 || bitPos >= m_numBits)
            throw new ArgumentOutOfRangeException("bitPos");
        // Вернуть состояние индексируемого бита
        return (m_byteArray[bitPos / 8] & (1 << (bitPos % 8))) != 0;
    }
    public void set_Item(Int32 bitPos, Boolean value)
    {
        if (bitPos < 0 || bitPos >= m_numBits)
            throw new ArgumentOutOfRangeException(
                "bitPos", bitPos.ToString());
        if (value)
        {
            // Установить индексируемый бит
            m_byteArray[bitPos / 8] = (Byte)
                (m_byteArray[bitPos / 8] | (1 << (bitPos % 8)));
        }
        else
        {
            // Сбросить индексируемый бит
            m_byteArray[bitPos / 8] = (Byte)
                (m_byteArray[bitPos / 8] & ~(1 << (bitPos % 8)));
        }
    }

    public static void Main()
    {
        // Выделить массив BitArray, который может хранить 14 бит
        BitArray ba = new BitArray(14);

        // Установить все четные биты вызовом метода доступа set
        for (Int32 x = 0; x < 14; x++)
        {
            ba[x] = (x % 2 == 0);
        }
        // Вывести состояние всех битов вызовом метода доступа get
        for (Int32 x = 0; x < 14; x++)
        {
            Console.WriteLine("Bit " + x + " is " + (ba[x] ? "On" : "Off"));
        }
    }

}

