using System;

namespace behaviac
{
	// Token: 0x020035E0 RID: 13792
	public static class bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi
	{
		// Token: 0x060153E9 RID: 87017 RVA: 0x00667578 File Offset: 0x00665978
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Monster_Abofeisi/Monster_Abofeisi_Event_Abofeisi");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(0);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(1);
			selector.AddChild(sequence);
			Condition_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node3 condition_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node = new Condition_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node3();
			condition_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node.SetId(3);
			sequence.AddChild(condition_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node.HasEvents());
			Condition_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node4 condition_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node2 = new Condition_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node4();
			condition_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node2.SetId(4);
			sequence.AddChild(condition_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node2.HasEvents());
			Action_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node5 action_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node = new Action_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node5();
			action_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node.SetClassNameString("Action");
			action_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node.SetId(5);
			sequence.AddChild(action_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(2);
			selector.AddChild(sequence2);
			Condition_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node7 condition_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node3 = new Condition_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node7();
			condition_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node3.SetId(7);
			sequence2.AddChild(condition_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node3.HasEvents());
			Condition_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node8 condition_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node4 = new Condition_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node8();
			condition_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node4.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node4.SetId(8);
			sequence2.AddChild(condition_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node4);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node4.HasEvents());
			Condition_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node9 condition_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node5 = new Condition_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node9();
			condition_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node5.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node5.SetId(9);
			sequence2.AddChild(condition_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node5);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node5.HasEvents());
			Action_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node10 action_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node2 = new Action_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node10();
			action_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node2.SetId(10);
			sequence2.AddChild(action_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
