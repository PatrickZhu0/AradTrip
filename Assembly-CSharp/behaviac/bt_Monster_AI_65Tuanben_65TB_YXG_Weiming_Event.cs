using System;

namespace behaviac
{
	// Token: 0x02002D36 RID: 11574
	public static class bt_Monster_AI_65Tuanben_65TB_YXG_Weiming_Event
	{
		// Token: 0x06014353 RID: 82771 RVA: 0x00612260 File Offset: 0x00610660
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/65Tuanben/65TB_YXG_Weiming_Event");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(1);
			bt.AddChild(sequence);
			Action_bt_Monster_AI_65Tuanben_65TB_YXG_Weiming_Event_node0 action_bt_Monster_AI_65Tuanben_65TB_YXG_Weiming_Event_node = new Action_bt_Monster_AI_65Tuanben_65TB_YXG_Weiming_Event_node0();
			action_bt_Monster_AI_65Tuanben_65TB_YXG_Weiming_Event_node.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_65TB_YXG_Weiming_Event_node.SetId(0);
			sequence.AddChild(action_bt_Monster_AI_65Tuanben_65TB_YXG_Weiming_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_65Tuanben_65TB_YXG_Weiming_Event_node.HasEvents());
			Action_bt_Monster_AI_65Tuanben_65TB_YXG_Weiming_Event_node2 action_bt_Monster_AI_65Tuanben_65TB_YXG_Weiming_Event_node2 = new Action_bt_Monster_AI_65Tuanben_65TB_YXG_Weiming_Event_node2();
			action_bt_Monster_AI_65Tuanben_65TB_YXG_Weiming_Event_node2.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_65TB_YXG_Weiming_Event_node2.SetId(2);
			sequence.AddChild(action_bt_Monster_AI_65Tuanben_65TB_YXG_Weiming_Event_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_65Tuanben_65TB_YXG_Weiming_Event_node2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
