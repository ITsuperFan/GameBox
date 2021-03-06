﻿/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

namespace GameBoxFramework.Utility
{
    /// <summary>
    /// 压缩解压缩相关的实用函数。
    /// </summary>
    public static partial class ZipHelper
    {
        private static IZipHelper s_ZipHelper = null;

        /// <summary>
        /// 设置压缩解压缩辅助器。
        /// </summary>
        /// <param name="zipHelper">要设置的压缩解压缩辅助器。</param>
        public static void SetZipHelper(IZipHelper zipHelper)
        {
            if (zipHelper == null)
            {
                throw new GameBoxFrameworkException("Zip helper is invalid.");
            }

            s_ZipHelper = zipHelper;
        }

        /// <summary>
        /// 压缩数据。
        /// </summary>
        /// <param name="bytes">要压缩的数据。</param>
        /// <returns>压缩后的数据。</returns>
        public static byte[] Compress(byte[] bytes)
        {
            if (s_ZipHelper == null)
            {
                throw new GameBoxFrameworkException("Zip helper is invalid.");
            }

            return s_ZipHelper.Compress(bytes);
        }

        /// <summary>
        /// 解压缩数据。
        /// </summary>
        /// <param name="bytes">要解压缩的数据。</param>
        /// <returns>解压缩后的数据。</returns>
        public static byte[] Decompress(byte[] bytes)
        {
            if (s_ZipHelper == null)
            {
                throw new GameBoxFrameworkException("Zip helper is invalid.");
            }

            return s_ZipHelper.Decompress(bytes);
        }
    }
}
