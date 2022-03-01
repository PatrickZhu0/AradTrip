using System;

namespace behaviac
{
	// Token: 0x02003686 RID: 13958
	public static class bt_Monster_AI_Monster_Daozei_Monster_Daozei_daozei_shutourenxiwu_event
	{
		// Token: 0x0601552B RID: 87339 RVA: 0x0066E8AC File Offset: 0x0066CCAC
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Monster_Daozei/Monster_Daozei_daozei_shutourenxiwu_event");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Condition_bt_Monster_AI_Monster_Daozei_Monster_Daozei_daozei_shutourenxiwu_event_node1 condition_bt_Monster_AI_Monster_Daozei_Monster_Daozei_daozei_shutourenxiwu_event_node = new Condition_bt_Monster_AI_Monster_Daozei_Monster_Daozei_daozei_shutourenxiwu_event_node1();
			condition_bt_Monster_AI_Monster_Daozei_Monster_Daozei_daozei_shutourenxiwu_event_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Daozei_Monster_Daozei_daozei_shutourenxiwu_event_node.SetId(1);
			sequence.AddChild(condition_bt_Monster_AI_Monster_Daozei_Monster_Daozei_daozei_shutourenxiwu_event_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Monster_Daozei_Monster_Daozei_daozei_shutourenxiwu_event_node.HasEvents());
			Action_bt_Monster_AI_Monster_Daozei_Monster_Daozei_daozei_shutourenxiwu_event_node2 action_bt_Monster_AI_Monster_Daozei_Monster_Daozei_daozei_shutourenxiwu_event_node = new Action_bt_Monster_AI_Monster_Daozei_Monster_Daozei_daozei_shutourenxiwu_event_node2();
			action_bt_Monster_AI_Monster_Daozei_Monster_Daozei_daozei_shutourenxiwu_event_node.SetClassNameString("Action");
			action_bt_Monster_AI_Monster_Daozei_Monster_Daozei_daozei_shutourenxiwu_event_node.SetId(2);
			sequence.AddChild(action_bt_Monster_AI_Monster_Daozei_Monster_Daozei_daozei_shutourenxiwu_event_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Monster_Daozei_Monster_Daozei_daozei_shutourenxiwu_event_node.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
