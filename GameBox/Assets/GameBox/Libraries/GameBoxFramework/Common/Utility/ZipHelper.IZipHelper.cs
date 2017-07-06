/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

namespace GameBoxFramework.Utility
{
    public static partial class ZipHelper
    {
        /// <summary>
        /// 压缩解压缩辅助器接口。
        /// </summary>
        public interface IZipHelper
        {
            /// <summary>
            /// 压缩数据。
            /// </summary>
            /// <param name="bytes">要压缩的数据。</param>
            /// <returns>压缩后的数据。</returns>
            byte[] Compress(byte[] bytes);

            /// <summary>
            /// 解压缩数据。
            /// </summary>
            /// <param name="bytes">要解压缩的数据。</param>
            /// <returns>解压缩后的数据。</returns>
            byte[] Decompress(byte[] bytes);
        }
    }
}
