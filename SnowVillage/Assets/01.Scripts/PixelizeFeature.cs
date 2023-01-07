using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PixelizeFeature : ScriptableRendererFeature//URP Render로 사용가능하게 만드는 CS
{
    [System.Serializable]
    public class CustonPassSetting{
        public RenderPassEvent renderPassEvent = RenderPassEvent.BeforeRenderingPostProcessing;//언제 랜더링 이벤트를 실행할건지 순서

        public int screenHeight = 256;//해상도
    }

    [SerializeField]
    private CustonPassSetting setting;

    private PixelizePass customPass;

    public override void Create()
    {
        customPass = new PixelizePass(setting);
    }

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        #if UNITY_EDITOR//유니티 에디터일 경우에만 실행/ 빌드할땐 안들어감/
        if(renderingData.cameraData.isSceneViewCamera) return;//SceneView면 안해주는 코드
        #endif
        renderer.EnqueuePass(customPass);
    }
}
