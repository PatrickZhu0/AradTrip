using System;

namespace behaviac
{
	// Token: 0x02003DA3 RID: 15779
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Zhaohuan_zibaoguai_Event_hard_node3 : Condition
	{
		// Token: 0x060162D9 RID: 90841 RVA: 0x006B45AC File Offset: 0x006B29AC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetMonsterCount();
			int num2 = 0;
			bool flag = num > num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
