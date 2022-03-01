using System;

namespace behaviac
{
	// Token: 0x020036CC RID: 14028
	public static class bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda
	{
		// Token: 0x060155B0 RID: 87472 RVA: 0x006713A0 File Offset: 0x0066F7A0
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Monster_Luguyouchong/Monster_Luguyouchongda");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(0);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(1);
			selector.AddChild(sequence);
			Action_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node26 action_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node = new Action_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node26();
			action_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node.SetClassNameString("Action");
			action_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node.SetId(26);
			sequence.AddChild(action_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node.HasEvents());
			Condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node2 condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node = new Condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node2();
			condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node.SetId(2);
			sequence.AddChild(condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node.HasEvents());
			Condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node3 condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node2 = new Condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node3();
			condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node2.SetId(3);
			sequence.AddChild(condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node2.HasEvents());
			Action_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node4 action_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node2 = new Action_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node4();
			action_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node2.SetId(4);
			sequence.AddChild(action_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(5);
			selector.AddChild(sequence2);
			Condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node6 condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node3 = new Condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node6();
			condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node3.SetId(6);
			sequence2.AddChild(condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node3.HasEvents());
			Condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node7 condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node4 = new Condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node7();
			condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node4.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node4.SetId(7);
			sequence2.AddChild(condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node4);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node4.HasEvents());
			Condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node8 condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node5 = new Condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node8();
			condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node5.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node5.SetId(8);
			sequence2.AddChild(condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node5);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node5.HasEvents());
			Action_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node9 action_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node3 = new Action_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node9();
			action_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node3.SetClassNameString("Action");
			action_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node3.SetId(9);
			sequence2.AddChild(action_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node3.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
