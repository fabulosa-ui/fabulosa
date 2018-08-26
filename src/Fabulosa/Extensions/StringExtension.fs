namespace Fabulosa.Extensions

module String =
    let isEmpty text = text = null || text = ""
    
    let isNotEmpty text = isEmpty text = false
                