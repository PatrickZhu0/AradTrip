using System;

namespace behaviac
{
	// Token: 0x020022CB RID: 8907
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node11 : Condition
	{
		// Token: 0x06012F11 RID: 77585 RVA: 0x00597B75 File Offset: 0x00595F75
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node11()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06012F12 RID: 77586 RVA: 0x00597B88 File Offset: 0x00595F88
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C923 RID: 51491
		private float opl_p0;
	}
}
