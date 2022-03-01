using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003E7B RID: 15995
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_Action_node5 : Action
	{
		// Token: 0x06016477 RID: 91255 RVA: 0x006BC868 File Offset: 0x006BAC68
		public Action_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_Action_node5()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 1;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 7286;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06016478 RID: 91256 RVA: 0x006BC8F8 File Offset: 0x006BACF8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FCAE RID: 64686
		private List<Input> method_p0;

		// Token: 0x0400FCAF RID: 64687
		private bool method_p1;
	}
}
