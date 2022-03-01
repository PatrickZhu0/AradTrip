using System;

namespace behaviac
{
	// Token: 0x02003158 RID: 12632
	public static class bt_Monster_AI_Chapter10_Yiliaobing_Event
	{
		// Token: 0x06014B4F RID: 84815 RVA: 0x0063C660 File Offset: 0x0063AA60
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Chapter10/Yiliaobing_Event");
			bt.IsFSM = false;
			Parallel_bt_Monster_AI_Chapter10_Yiliaobing_Event_node5 parallel_bt_Monster_AI_Chapter10_Yiliaobing_Event_node = new Parallel_bt_Monster_AI_Chapter10_Yiliaobing_Event_node5();
			parallel_bt_Monster_AI_Chapter10_Yiliaobing_Event_node.SetClassNameString("Parallel");
			parallel_bt_Monster_AI_Chapter10_Yiliaobing_Event_node.SetId(5);
			bt.AddChild(parallel_bt_Monster_AI_Chapter10_Yiliaobing_Event_node);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(6);
			parallel_bt_Monster_AI_Chapter10_Yiliaobing_Event_node.AddChild(sequence);
			Condition_bt_Monster_AI_Chapter10_Yiliaobing_Event_node7 condition_bt_Monster_AI_Chapter10_Yiliaobing_Event_node = new Condition_bt_Monster_AI_Chapter10_Yiliaobing_Event_node7();
			condition_bt_Monster_AI_Chapter10_Yiliaobing_Event_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Chapter10_Yiliaobing_Event_node.SetId(7);
			sequence.AddChild(condition_bt_Monster_AI_Chapter10_Yiliaobing_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Chapter10_Yiliaobing_Event_node.HasEvents());
			Action_bt_Monster_AI_Chapter10_Yiliaobing_Event_node8 action_bt_Monster_AI_Chapter10_Yiliaobing_Event_node = new Action_bt_Monster_AI_Chapter10_Yiliaobing_Event_node8();
			action_bt_Monster_AI_Chapter10_Yiliaobing_Event_node.SetClassNameString("Action");
			action_bt_Monster_AI_Chapter10_Yiliaobing_Event_node.SetId(8);
			sequence.AddChild(action_bt_Monster_AI_Chapter10_Yiliaobing_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Chapter10_Yiliaobing_Event_node.HasEvents());
			parallel_bt_Monster_AI_Chapter10_Yiliaobing_Event_node.SetHasEvents(parallel_bt_Monster_AI_Chapter10_Yiliaobing_Event_node.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(9);
			parallel_bt_Monster_AI_Chapter10_Yiliaobing_Event_node.AddChild(sequence2);
			Condition_bt_Monster_AI_Chapter10_Yiliaobing_Event_node10 condition_bt_Monster_AI_Chapter10_Yiliaobing_Event_node2 = new Condition_bt_Monster_AI_Chapter10_Yiliaobing_Event_node10();
			condition_bt_Monster_AI_Chapter10_Yiliaobing_Event_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Chapter10_Yiliaobing_Event_node2.SetId(10);
			sequence2.AddChild(condition_bt_Monster_AI_Chapter10_Yiliaobing_Event_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Chapter10_Yiliaobing_Event_node2.HasEvents());
			Action_bt_Monster_AI_Chapter10_Yiliaobing_Event_node11 action_bt_Monster_AI_Chapter10_Yiliaobing_Event_node2 = new Action_bt_Monster_AI_Chapter10_Yiliaobing_Event_node11();
			action_bt_Monster_AI_Chapter10_Yiliaobing_Event_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Chapter10_Yiliaobing_Event_node2.SetId(11);
			sequence2.AddChild(action_bt_Monster_AI_Chapter10_Yiliaobing_Event_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Chapter10_Yiliaobing_Event_node2.HasEvents());
			parallel_bt_Monster_AI_Chapter10_Yiliaobing_Event_node.SetHasEvents(parallel_bt_Monster_AI_Chapter10_Yiliaobing_Event_node.HasEvents() | sequence2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | parallel_bt_Monster_AI_Chapter10_Yiliaobing_Event_node.HasEvents());
			return true;
		}
	}
}
