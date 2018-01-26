using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameStateTests {

	// [Test]
	// public void GameStateTestsSimplePasses() {
		
	// }

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator GameStateTestsWithEnumeratorPasses() {
		SceneManager.LoadScene("main");
		Assert.That(SceneManager.sceneCount, Is.EqualTo(2));
		yield return null;
	}
}
