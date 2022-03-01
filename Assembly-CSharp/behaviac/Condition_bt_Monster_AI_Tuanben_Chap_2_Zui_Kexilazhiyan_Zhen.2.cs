using System;

namespace behaviac
{
	// Token: 0x020037E4 RID: 14308
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Zhengchangtai_Hard_node0 : Condition
	{
		// Token: 0x060157C1 RID: 88001 RVA: 0x0067C1C4 File Offset: 0x0067A5C4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Conditon_IsDayTime();
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
