﻿//-----------------------------------------------------------------------
// <copyright file= "Department.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-02-19 20:42:35
// Modified by:
// Description: 院系信息表
//-----------------------------------------------------------------------
using PSU.Entity.Dormitory;
using PSU.Utility.System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSU.Entity.School
{
    public class Department : SysField
    {
        #region Attribute

        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public string DepartmentOID { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        [Required]
        public long Id { get; set; } = TimeUtility.GetTimespans();

        /// <summary>
        /// 院系名称
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// 所属校区名称
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string CampusName { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        [MaxLength(200)]
        public string Address { get; set; }

        /// <summary>
        /// 联系方式
        /// </summary>
        [MaxLength(20)]
        public string Tel { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// 官方微博
        /// </summary>
        [MaxLength(20)]
        public string Weibo { get; set; }

        /// <summary>
        /// 官方微信公众号
        /// </summary>
        [MaxLength(50)]
        public string Wechat { get; set; }

        /// <summary>
        /// 官方QQ
        /// </summary>
        [MaxLength(20)]
        public long QQ { get; set; }

        /// <summary>
        /// 介绍
        /// </summary>
        [MaxLength(200)]
        public string Introduction { get; set; }

        /// <summary>
        /// 展示图地址
        /// </summary>
        [MaxLength(500)]
        public string ImageSrc { get; set; }

        /// <summary>
        /// 展示图二进制流
        /// </summary>
        public byte Image { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// 是否为部门
        /// </summary>
        public bool IsBranch { get; set; }

        #endregion

        #region Foreign Key

        /// <summary>
        /// 学校主键
        /// </summary>
        public string CollageFK { get; set; }

        /// <summary>
        /// 校区主键
        /// </summary>
        public string CampusFK { get; set; }

        [ForeignKey("CollageFK")]
        public virtual College Collage { get; set; }

        [ForeignKey("CampusFK")]
        public virtual Campus Campus { get; set; }

        #endregion
    }
}
