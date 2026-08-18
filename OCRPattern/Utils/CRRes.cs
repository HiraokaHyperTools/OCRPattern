using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OCRPattern.Utils
{
    public enum CRRes
    {
        /// <summary>
        /// `通常(フォーム検出成功)`
        /// </summary>
        Avail,

        /// <summary>
        /// `検出：失敗` など
        /// </summary>
        Fail,

        /// <summary>
        /// `区切り/代表ページ` あり
        /// </summary>
        TemplatePage,

        /// <summary>
        /// `表紙付きモード`
        /// </summary>
        SaveAll,

        /// <summary>
        /// `表紙付き、表紙は削除`
        /// </summary>
        SaveAllWithoutFirstPage,
    }
}
