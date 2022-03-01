using System;

namespace behaviac
{
	// Token: 0x0200355B RID: 13659
	public static class bt_Monster_AI_Heisedadi_Yichangyuanhun_Destiation
	{
		// Token: 0x060152F4 RID: 86772 RVA: 0x006627A4 File Offset: 0x00660BA4
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Heisedadi/Yichangyuanhun_Destiation");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(3);
			bt.AddChild(selector);
			Action_bt_Monster_AI_Heisedadi_Yichangyuanhun_Destiation_node6 action_bt_Monster_AI_Heisedadi_Yichangyuanhun_Destiation_node = new Action_bt_Monster_AI_Heisedadi_Yichangyuanhun_Destiation_node6();
			action_bt_Monster_AI_Heisedadi_Yichangyuanhun_Destiation_node.SetClassNameString("Action");
			action_bt_Monster_AI_Heisedadi_Yichangyuanhun_Destiation_node.SetId(6);
			selector.AddChild(action_bt_Monster_AI_Heisedadi_Yichangyuanhun_Destiation_node);
			selector.SetHasEvents(selector.HasEvents() | action_bt_Monster_AI_Heisedadi_Yichangyuanhun_Destiation_node.HasEvents());
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(4);
			selector.AddChild(sequence);
			Condition_bt_Monster_AI_Heisedadi_Yichangyuanhun_Destiation_node5 condition_bt_Monster_AI_Heisedadi_Yichangyuanhun_Destiation_node = new Condition_bt_Monster_AI_Heisedadi_Yichangyuanhun_Destiation_node5();
			condition_bt_Monster_AI_Heisedadi_Yichangyuanhun_Destiation_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Heisedadi_Yichangyuanhun_Destiation_node.SetId(5);
			sequence.AddChild(condition_bt_Monster_AI_Heisedadi_Yichangyuanhun_Destiation_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Heisedadi_Yichangyuanhun_Destiation_node.HasEvents());
			Action_bt_Monster_AI_Heisedadi_Yichangyuanhun_Destiation_node7 action_bt_Monster_AI_Heisedadi_Yichangyuanhun_Destiation_node2 = new Action_bt_Monster_AI_Heisedadi_Yichangyuanhun_Destiation_node7();
			action_bt_Monster_AI_Heisedadi_Yichangyuanhun_Destiation_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Heisedadi_Yichangyuanhun_Destiation_node2.SetId(7);
			sequence.AddChild(action_bt_Monster_AI_Heisedadi_Yichangyuanhun_Destiation_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Heisedadi_Yichangyuanhun_Destiation_node2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(0);
			selector.AddChild(sequence2);
			Condition_bt_Monster_AI_Heisedadi_Yichangyuanhun_Destiation_node2 condition_bt_Monster_AI_Heisedadi_Yichangyuanhun_Destiation_node2 = new Condition_bt_Monster_AI_Heisedadi_Yichangyuanhun_Destiation_node2();
			condition_bt_Monster_AI_Heisedadi_Yichangyuanhun_Destiation_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Heisedadi_Yichangyuanhun_Destiation_node2.SetId(2);
			sequence2.AddChild(condition_bt_Monster_AI_Heisedadi_Yichangyuanhun_Destiation_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Heisedadi_Yichangyuanhun_Destiation_node2.HasEvents());
			Action_bt_Monster_AI_Heisedadi_Yichangyuanhun_Destiation_node1 action_bt_Monster_AI_Heisedadi_Yichangyuanhun_Destiation_node3 = new Action_bt_Monster_AI_Heisedadi_Yichangyuanhun_Destiation_node1();
			action_bt_Monster_AI_Heisedadi_Yichangyuanhun_Destiation_node3.SetClassNameString("Action");
			action_bt_Monster_AI_Heisedadi_Yichangyuanhun_Destiation_node3.SetId(1);
			sequence2.AddChild(action_bt_Monster_AI_Heisedadi_Yichangyuanhun_Destiation_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Heisedadi_Yichangyuanhun_Destiation_node3.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
