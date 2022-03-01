using System;
using UnityEngine;

// Token: 0x02000244 RID: 580
public class PlayerEffect : MonoBehaviour
{
	// Token: 0x06001310 RID: 4880 RVA: 0x00066214 File Offset: 0x00064614
	private void SingleLeftFire()
	{
		GameObject gameObject = Object.Instantiate<GameObject>((!this.Player.IsForward) ? this.SingleLeftBack : this.SingleLeft, this.Player.transform.position, this.Player.transform.rotation);
		gameObject.transform.parent = this.Player.transform;
	}

	// Token: 0x06001311 RID: 4881 RVA: 0x00066280 File Offset: 0x00064680
	private void DoubleLeftFire()
	{
		GameObject gameObject = Object.Instantiate<GameObject>((!this.Player.IsForward) ? this.DoubleLeftBack : this.DoubleLeft, this.Player.transform.position, this.Player.transform.rotation);
		gameObject.transform.parent = this.Player.transform;
	}

	// Token: 0x06001312 RID: 4882 RVA: 0x000662EC File Offset: 0x000646EC
	private void DoubleRightFire()
	{
		GameObject gameObject = Object.Instantiate<GameObject>((!this.Player.IsForward) ? this.DoubleRightBack : this.DoubleRight, this.Player.transform.position, this.Player.transform.rotation);
		gameObject.transform.parent = this.Player.transform;
	}

	// Token: 0x06001313 RID: 4883 RVA: 0x00066358 File Offset: 0x00064758
	private void AddBuff()
	{
		GameObject gameObject = Object.Instantiate<GameObject>((!this.Player.IsForward) ? this.BuffBack : this.Buff, this.Player.transform.position, this.Player.transform.rotation);
		gameObject.transform.parent = this.Player.transform;
	}

	// Token: 0x06001314 RID: 4884 RVA: 0x000663C4 File Offset: 0x000647C4
	private void AddDust()
	{
		GameObject gameObject = Object.Instantiate<GameObject>((!this.Player.IsForward) ? this.DustBack : this.Dust, this.Player.transform.position, this.Player.transform.rotation);
		gameObject.transform.parent = this.Player.transform;
	}

	// Token: 0x06001315 RID: 4885 RVA: 0x00066430 File Offset: 0x00064830
	private void GunFireDown()
	{
		GameObject gameObject = Object.Instantiate<GameObject>((!this.Player.IsForward) ? this.DownAttackBack : this.DownAttack, this.Player.transform.position, this.Player.transform.rotation);
		gameObject.transform.parent = this.Player.transform;
		Object.Instantiate<GameObject>((!this.Player.IsForward) ? this.DownAttackRemainBack : this.DownAttackRemain, this.Player.transform.position, this.Player.transform.rotation);
	}

	// Token: 0x06001316 RID: 4886 RVA: 0x000664E4 File Offset: 0x000648E4
	private void GunFireForward()
	{
		GameObject gameObject = Object.Instantiate<GameObject>((!this.Player.IsForward) ? this.FireForwardBack : this.FireForward, this.Player.transform.position, this.Player.transform.rotation);
		gameObject.transform.parent = this.Player.transform;
	}

	// Token: 0x06001317 RID: 4887 RVA: 0x00066550 File Offset: 0x00064950
	private void GunFireUp()
	{
		GameObject gameObject = Object.Instantiate<GameObject>((!this.Player.IsForward) ? this.FireUpBack : this.FireUp, this.Player.transform.position, this.Player.transform.rotation);
		gameObject.transform.parent = this.Player.transform;
	}

	// Token: 0x06001318 RID: 4888 RVA: 0x000665BC File Offset: 0x000649BC
	private void GunWalkLeft()
	{
		GameObject gameObject = Object.Instantiate<GameObject>((!this.Player.IsForward) ? this.Walk_LeftBack : this.Walk_Left, this.Player.transform.position, this.Player.transform.rotation);
		gameObject.transform.parent = this.Player.transform;
	}

	// Token: 0x06001319 RID: 4889 RVA: 0x00066628 File Offset: 0x00064A28
	private void GunWalkRight()
	{
		GameObject gameObject = Object.Instantiate<GameObject>((!this.Player.IsForward) ? this.Walk_RightBack : this.Walk_Right, this.Player.transform.position, this.Player.transform.rotation);
		gameObject.transform.parent = this.Player.transform;
	}

	// Token: 0x0600131A RID: 4890 RVA: 0x00066694 File Offset: 0x00064A94
	private void GunLuanshe()
	{
		GameObject gameObject = Object.Instantiate<GameObject>((!this.Player.IsForward) ? this.LuansheBack : this.Luanshe, this.Player.transform.position, this.Player.transform.rotation);
		gameObject.transform.parent = this.Player.transform;
	}

	// Token: 0x0600131B RID: 4891 RVA: 0x00066700 File Offset: 0x00064B00
	private void GunTashe()
	{
		GameObject gameObject = Object.Instantiate<GameObject>((!this.Player.IsForward) ? this.TasheBack : this.Tashe, this.Player.transform.position, this.Player.transform.rotation);
		gameObject.transform.parent = this.Player.transform;
	}

	// Token: 0x0600131C RID: 4892 RVA: 0x0006676C File Offset: 0x00064B6C
	private void GunHuixuanti()
	{
		GameObject gameObject = Object.Instantiate<GameObject>((!this.Player.IsForward) ? this.HuixuantiBack : this.Huixuanti, this.Player.transform.position, this.Player.transform.rotation);
		gameObject.transform.parent = this.Player.transform;
	}

	// Token: 0x04000CB8 RID: 3256
	public Player Player;

	// Token: 0x04000CB9 RID: 3257
	[Header("原地攻击")]
	public GameObject SingleLeft;

	// Token: 0x04000CBA RID: 3258
	public GameObject DoubleLeft;

	// Token: 0x04000CBB RID: 3259
	public GameObject DoubleRight;

	// Token: 0x04000CBC RID: 3260
	public GameObject SingleLeftBack;

	// Token: 0x04000CBD RID: 3261
	public GameObject DoubleLeftBack;

	// Token: 0x04000CBE RID: 3262
	public GameObject DoubleRightBack;

	// Token: 0x04000CBF RID: 3263
	[Header("BUFF")]
	public GameObject Buff;

	// Token: 0x04000CC0 RID: 3264
	public GameObject BuffBack;

	// Token: 0x04000CC1 RID: 3265
	[Header("铲地")]
	public GameObject Dust;

	// Token: 0x04000CC2 RID: 3266
	public GameObject DustBack;

	// Token: 0x04000CC3 RID: 3267
	[Header("对地")]
	public GameObject DownAttack;

	// Token: 0x04000CC4 RID: 3268
	public GameObject DownAttackRemain;

	// Token: 0x04000CC5 RID: 3269
	public GameObject DownAttackBack;

	// Token: 0x04000CC6 RID: 3270
	public GameObject DownAttackRemainBack;

	// Token: 0x04000CC7 RID: 3271
	[Header("机枪")]
	public GameObject FireForward;

	// Token: 0x04000CC8 RID: 3272
	public GameObject FireUp;

	// Token: 0x04000CC9 RID: 3273
	public GameObject FireForwardBack;

	// Token: 0x04000CCA RID: 3274
	public GameObject FireUpBack;

	// Token: 0x04000CCB RID: 3275
	[Header("移动射击")]
	public GameObject Walk_Left;

	// Token: 0x04000CCC RID: 3276
	public GameObject Walk_Right;

	// Token: 0x04000CCD RID: 3277
	public GameObject Walk_LeftBack;

	// Token: 0x04000CCE RID: 3278
	public GameObject Walk_RightBack;

	// Token: 0x04000CCF RID: 3279
	[Header("乱射")]
	public GameObject Luanshe;

	// Token: 0x04000CD0 RID: 3280
	public GameObject LuansheBack;

	// Token: 0x04000CD1 RID: 3281
	[Header("踏射")]
	public GameObject Tashe;

	// Token: 0x04000CD2 RID: 3282
	public GameObject TasheBack;

	// Token: 0x04000CD3 RID: 3283
	[Header("回旋踢")]
	public GameObject Huixuanti;

	// Token: 0x04000CD4 RID: 3284
	public GameObject HuixuantiBack;
}
