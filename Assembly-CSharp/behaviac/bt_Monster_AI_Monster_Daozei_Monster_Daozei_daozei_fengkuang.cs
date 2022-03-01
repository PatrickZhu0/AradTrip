using System;

namespace behaviac
{
	// Token: 0x02003683 RID: 13955
	public static class bt_Monster_AI_Monster_Daozei_Monster_Daozei_daozei_fengkuangdaofei_event
	{
		// Token: 0x06015526 RID: 87334 RVA: 0x0066E6EC File Offset: 0x0066CAEC
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Monster_Daozei/Monster_Daozei_daozei_fengkuangdaofei_event");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Condition_bt_Monster_AI_Monster_Daozei_Monster_Daozei_daozei_fengkuangdaofei_event_node1 condition_bt_Monster_AI_Monster_Daozei_Monster_Daozei_daozei_fengkuangdaofei_event_node = new Condition_bt_Monster_AI_Monster_Daozei_Monster_Daozei_daozei_fengkuangdaofei_event_node1();
			condition_bt_Monster_AI_Monster_Daozei_Monster_Daozei_daozei_fengkuangdaofei_event_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Daozei_Monster_Daozei_daozei_fengkuangdaofei_event_node.SetId(1);
			sequence.AddChild(condition_bt_Monster_AI_Monster_Daozei_Monster_Daozei_daozei_fengkuangdaofei_event_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Monster_Daozei_Monster_Daozei_daozei_fengkuangdaofei_event_node.HasEvents());
			Action_bt_Monster_AI_Monster_Daozei_Monster_Daozei_daozei_fengkuangdaofei_event_node2 action_bt_Monster_AI_Monster_Daozei_Monster_Daozei_daozei_fengkuangdaofei_event_node = new Action_bt_Monster_AI_Monster_Daozei_Monster_Daozei_daozei_fengkuangdaofei_event_node2();
			action_bt_Monster_AI_Monster_Daozei_Monster_Daozei_daozei_fengkuangdaofei_event_node.SetClassNameString("Action");
			action_bt_Monster_AI_Monster_Daozei_Monster_Daozei_daozei_fengkuangdaofei_event_node.SetId(2);
			sequence.AddChild(action_bt_Monster_AI_Monster_Daozei_Monster_Daozei_daozei_fengkuangdaofei_event_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Monster_Daozei_Monster_Daozei_daozei_fengkuangdaofei_event_node.HasEvents());
			Action_bt_Monster_AI_Monster_Daozei_Monster_Daozei_daozei_fengkuangdaofei_event_node3 action_bt_Monster_AI_Monster_Daozei_Monster_Daozei_daozei_fengkuangdaofei_event_node2 = new Action_bt_Monster_AI_Monster_Daozei_Monster_Daozei_daozei_fengkuangdaofei_event_node3();
			action_bt_Monster_AI_Monster_Daozei_Monster_Daozei_daozei_fengkuangdaofei_event_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Monster_Daozei_Monster_Daozei_daozei_fengkuangdaofei_event_node2.SetId(3);
			sequence.AddChild(action_bt_Monster_AI_Monster_Daozei_Monster_Daozei_daozei_fengkuangdaofei_event_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Monster_Daozei_Monster_Daozei_daozei_fengkuangdaofei_event_node2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
