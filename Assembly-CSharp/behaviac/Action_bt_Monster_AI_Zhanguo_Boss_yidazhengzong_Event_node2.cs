using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003EA2 RID: 16034
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_Event_node2 : Action
	{
		// Token: 0x060164C3 RID: 91331 RVA: 0x006BE4B4 File Offset: 0x006BC8B4
		public Action_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_Event_node2()
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
			item.skillID = 7287;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060164C4 RID: 91332 RVA: 0x006BE544 File Offset: 0x006BC944
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FCF5 RID: 64757
		private List<Input> method_p0;

		// Token: 0x0400FCF6 RID: 64758
		private bool method_p1;
	}
}
