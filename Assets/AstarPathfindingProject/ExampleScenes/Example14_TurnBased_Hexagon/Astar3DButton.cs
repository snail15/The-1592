using UnityEngine;

namespace Pathfinding.Examples {
    /// <summary>Helper script in the example scene 'Turn Based'</summary>
    [HelpURL("http://arongranberg.com/astar/documentation/stable/class_pathfinding_1_1_examples_1_1_astar3_d_button.php")]
    public class Astar3DButton : MonoBehaviour {
        public GraphNode node;

        public void OnHover(bool hover)
        {
            // TODO: Play animation
        }

        public void OnClick()
        {
            // TODO: Play animation

            node = AstarPath.active.GetNearest(gameObject.transform.position, NNConstraint.Default).node;
        }
    }
}
