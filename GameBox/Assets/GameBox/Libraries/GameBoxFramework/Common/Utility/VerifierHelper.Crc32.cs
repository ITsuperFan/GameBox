﻿/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using System.Security.Cryptography;

namespace GameBoxFramework.Utility
{
    public static partial class VerifierHelper
    {
        /// <summary>
        /// CRC32 算法。
        /// </summary>
        private class Crc32 : HashAlgorithm
        {
            private static uint[] DefaultTable = null;

            /// <summary>
            /// 默认多项式。
            /// </summary>
            public const uint DefaultPolynomial = 0xedb88320;

            /// <summary>
            /// 默认种子数。
            /// </summary>
            public const uint DefaultSeed = 0xffffffff;

            private uint hash;
            private uint seed;
            private uint[] table;

            /// <summary>
            /// 初始化 CRC32 类的新实例。
            /// </summary>
            public Crc32()
            {
                hash = 0;
                seed = DefaultSeed;
                table = InitializeTable(DefaultPolynomial);
                hash = seed;
            }

            /// <summary>
            /// 初始化 CRC32 类的新实例。
            /// </summary>
            /// <param name="polynomial">指定的多项式。</param>
            /// <param name="seed">指定的种子数。</param>
            public Crc32(uint polynomial, uint seed)
            {
                table = InitializeTable(polynomial);
                this.seed = seed;
                hash = seed;
            }

            /// <summary>
            /// 初始化 Crc32 类的实现。
            /// </summary>
            public override void Initialize()
            {
                hash = seed;
            }

            /// <summary>
            /// 将写入对象的数据路由到哈希算法以计算哈希值。
            /// </summary>
            /// <param name="array">要计算其哈希代码的输入。</param>
            /// <param name="ibStart">字节数组中的偏移量，从该位置开始使用数据。</param>
            /// <param name="cbSize">字节数组中用作数据的字节数。</param>
            protected override void HashCore(byte[] array, int ibStart, int cbSize)
            {
                hash = CalculateHash(table, hash, array, ibStart, cbSize);
            }

            /// <summary>
            /// 在加密流对象处理完最后的数据后完成哈希计算。
            /// </summary>
            /// <returns>计算所得的哈希代码。</returns>
            protected override byte[] HashFinal()
            {
                byte[] hashBuffer = UintToBigEndianBytes(~hash);
                HashValue = hashBuffer;
                return hashBuffer;
            }

            private static uint[] InitializeTable(uint polynomial)
            {
                if (polynomial == DefaultPolynomial && DefaultTable != null)
                {
                    return DefaultTable;
                }

                uint[] createTable = new uint[256];
                for (int i = 0; i < 256; i++)
                {
                    uint entry = (uint)i;
                    for (int j = 0; j < 8; j++)
                    {
                        if ((entry & 1) == 1)
                        {
                            entry = (entry >> 1) ^ polynomial;
                        }
                        else
                        {
                            entry = entry >> 1;
                        }
                    }

                    createTable[i] = entry;
                }

                if (polynomial == DefaultPolynomial)
                {
                    DefaultTable = createTable;
                }

                return createTable;
            }

            private static uint CalculateHash(uint[] table, uint seed, byte[] bytes, int start, int size)
            {
                uint crc = seed;
                for (int i = start; i < size; i++)
                {
                    unchecked
                    {
                        crc = (crc >> 8) ^ table[bytes[i] ^ crc & 0xff];
                    }
                }
                return crc;
            }

            private static byte[] UintToBigEndianBytes(uint x)
            {
                return new byte[] { (byte)((x >> 24) & 0xff), (byte)((x >> 16) & 0xff), (byte)((x >> 8) & 0xff), (byte)(x & 0xff) };
            }
        }
    }
}
