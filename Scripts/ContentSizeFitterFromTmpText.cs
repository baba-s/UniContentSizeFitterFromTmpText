using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Kogane
{
	[DisallowMultipleComponent]
	public sealed class ContentSizeFitterFromTmpText : MonoBehaviour
	{
		[SerializeField] private RectTransform     m_self              = default;
		[SerializeField] private TMP_Text          m_tmpText           = default;
		[SerializeField] private ContentSizeFitter m_contentSizeFitter = default;
		[SerializeField] private Vector2           m_offset            = default;

		private void Reset()
		{
			m_self              = GetComponent<RectTransform>();
			m_tmpText           = GetComponentInChildren<TMP_Text>();
			m_contentSizeFitter = GetComponentInChildren<ContentSizeFitter>();
		}

		public void Fit()
		{
			Fit
			(
				target: m_self,
				tmpText: m_tmpText,
				contentSizeFitter: m_contentSizeFitter,
				offset: m_offset
			);
		}

		public static void Fit
		(
			RectTransform     target,
			TMP_Text          tmpText,
			ContentSizeFitter contentSizeFitter,
			Vector2           offset
		)
		{
			tmpText.ForceMeshUpdate();
			contentSizeFitter.SetLayoutHorizontal();
			contentSizeFitter.SetLayoutVertical();

			var sizeDelta = new Vector2( tmpText.preferredWidth, tmpText.preferredHeight );

			sizeDelta += offset;

			target.sizeDelta = sizeDelta;
		}
	}
}