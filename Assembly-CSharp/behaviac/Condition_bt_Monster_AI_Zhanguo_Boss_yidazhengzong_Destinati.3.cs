using System;

namespace behaviac
{
	// Token: 0x02003E8F RID: 16015
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_DestinationSelect_node4 : Condition
	{
		// Token: 0x0601649E RID: 91294 RVA: 0x006BD934 File Offset: 0x006BBD34
		public Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_DestinationSelect_node4()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x0601649F RID: 91295 RVA: 0x006BD948 File Offset: 0x006BBD48
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FCD8 RID: 64728
		private float opl_p0;
	}
}
