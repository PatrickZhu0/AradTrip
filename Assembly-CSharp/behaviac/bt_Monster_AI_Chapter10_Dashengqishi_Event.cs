using System;

namespace behaviac
{
	// Token: 0x020030EB RID: 12523
	public static class bt_Monster_AI_Chapter10_Dashengqishi_Event
	{
		// Token: 0x06014A89 RID: 84617 RVA: 0x006387B0 File Offset: 0x00636BB0
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Chapter10/Dashengqishi_Event");
			bt.IsFSM = false;
			Parallel_bt_Monster_AI_Chapter10_Dashengqishi_Event_node0 parallel_bt_Monster_AI_Chapter10_Dashengqishi_Event_node = new Parallel_bt_Monster_AI_Chapter10_Dashengqishi_Event_node0();
			parallel_bt_Monster_AI_Chapter10_Dashengqishi_Event_node.SetClassNameString("Parallel");
			parallel_bt_Monster_AI_Chapter10_Dashengqishi_Event_node.SetId(0);
			bt.AddChild(parallel_bt_Monster_AI_Chapter10_Dashengqishi_Event_node);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(5);
			parallel_bt_Monster_AI_Chapter10_Dashengqishi_Event_node.AddChild(sequence);
			Condition_bt_Monster_AI_Chapter10_Dashengqishi_Event_node7 condition_bt_Monster_AI_Chapter10_Dashengqishi_Event_node = new Condition_bt_Monster_AI_Chapter10_Dashengqishi_Event_node7();
			condition_bt_Monster_AI_Chapter10_Dashengqishi_Event_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Chapter10_Dashengqishi_Event_node.SetId(7);
			sequence.AddChild(condition_bt_Monster_AI_Chapter10_Dashengqishi_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Chapter10_Dashengqishi_Event_node.HasEvents());
			Condition_bt_Monster_AI_Chapter10_Dashengqishi_Event_node6 condition_bt_Monster_AI_Chapter10_Dashengqishi_Event_node2 = new Condition_bt_Monster_AI_Chapter10_Dashengqishi_Event_node6();
			condition_bt_Monster_AI_Chapter10_Dashengqishi_Event_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Chapter10_Dashengqishi_Event_node2.SetId(6);
			sequence.AddChild(condition_bt_Monster_AI_Chapter10_Dashengqishi_Event_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Chapter10_Dashengqishi_Event_node2.HasEvents());
			Condition_bt_Monster_AI_Chapter10_Dashengqishi_Event_node9 condition_bt_Monster_AI_Chapter10_Dashengqishi_Event_node3 = new Condition_bt_Monster_AI_Chapter10_Dashengqishi_Event_node9();
			condition_bt_Monster_AI_Chapter10_Dashengqishi_Event_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_Chapter10_Dashengqishi_Event_node3.SetId(9);
			sequence.AddChild(condition_bt_Monster_AI_Chapter10_Dashengqishi_Event_node3);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Chapter10_Dashengqishi_Event_node3.HasEvents());
			Action_bt_Monster_AI_Chapter10_Dashengqishi_Event_node10 action_bt_Monster_AI_Chapter10_Dashengqishi_Event_node = new Action_bt_Monster_AI_Chapter10_Dashengqishi_Event_node10();
			action_bt_Monster_AI_Chapter10_Dashengqishi_Event_node.SetClassNameString("Action");
			action_bt_Monster_AI_Chapter10_Dashengqishi_Event_node.SetId(10);
			sequence.AddChild(action_bt_Monster_AI_Chapter10_Dashengqishi_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Chapter10_Dashengqishi_Event_node.HasEvents());
			Action_bt_Monster_AI_Chapter10_Dashengqishi_Event_node8 action_bt_Monster_AI_Chapter10_Dashengqishi_Event_node2 = new Action_bt_Monster_AI_Chapter10_Dashengqishi_Event_node8();
			action_bt_Monster_AI_Chapter10_Dashengqishi_Event_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Chapter10_Dashengqishi_Event_node2.SetId(8);
			sequence.AddChild(action_bt_Monster_AI_Chapter10_Dashengqishi_Event_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Chapter10_Dashengqishi_Event_node2.HasEvents());
			parallel_bt_Monster_AI_Chapter10_Dashengqishi_Event_node.SetHasEvents(parallel_bt_Monster_AI_Chapter10_Dashengqishi_Event_node.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(1);
			parallel_bt_Monster_AI_Chapter10_Dashengqishi_Event_node.AddChild(sequence2);
			Condition_bt_Monster_AI_Chapter10_Dashengqishi_Event_node2 condition_bt_Monster_AI_Chapter10_Dashengqishi_Event_node4 = new Condition_bt_Monster_AI_Chapter10_Dashengqishi_Event_node2();
			condition_bt_Monster_AI_Chapter10_Dashengqishi_Event_node4.SetClassNameString("Condition");
			condition_bt_Monster_AI_Chapter10_Dashengqishi_Event_node4.SetId(2);
			sequence2.AddChild(condition_bt_Monster_AI_Chapter10_Dashengqishi_Event_node4);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Chapter10_Dashengqishi_Event_node4.HasEvents());
			Condition_bt_Monster_AI_Chapter10_Dashengqishi_Event_node3 condition_bt_Monster_AI_Chapter10_Dashengqishi_Event_node5 = new Condition_bt_Monster_AI_Chapter10_Dashengqishi_Event_node3();
			condition_bt_Monster_AI_Chapter10_Dashengqishi_Event_node5.SetClassNameString("Condition");
			condition_bt_Monster_AI_Chapter10_Dashengqishi_Event_node5.SetId(3);
			sequence2.AddChild(condition_bt_Monster_AI_Chapter10_Dashengqishi_Event_node5);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Chapter10_Dashengqishi_Event_node5.HasEvents());
			Action_bt_Monster_AI_Chapter10_Dashengqishi_Event_node4 action_bt_Monster_AI_Chapter10_Dashengqishi_Event_node3 = new Action_bt_Monster_AI_Chapter10_Dashengqishi_Event_node4();
			action_bt_Monster_AI_Chapter10_Dashengqishi_Event_node3.SetClassNameString("Action");
			action_bt_Monster_AI_Chapter10_Dashengqishi_Event_node3.SetId(4);
			sequence2.AddChild(action_bt_Monster_AI_Chapter10_Dashengqishi_Event_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Chapter10_Dashengqishi_Event_node3.HasEvents());
			parallel_bt_Monster_AI_Chapter10_Dashengqishi_Event_node.SetHasEvents(parallel_bt_Monster_AI_Chapter10_Dashengqishi_Event_node.HasEvents() | sequence2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | parallel_bt_Monster_AI_Chapter10_Dashengqishi_Event_node.HasEvents());
			return true;
		}
	}
}
