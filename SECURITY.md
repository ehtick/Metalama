# Security Policy

Metalama is a compiler that runs locally on your development machine or on a build agent. 

It does not access the network except for telemetry.

It does not process confidential data except source code, which always remains on the device that executes Metalama.

Therefore, potential vulnerabilities in Metalama or in its dependencies should have minimal impact. Nevertheless, we try to keep our dependencies up to date.

The most dangerous scenario with Metalama would be a supply chain attach where harmful code would be injected into Metalama and attach its users. To protect ourselves and our customers against this scenario, we implement the following measures:

- The product is open source, except some extensions that are source available
- We sign our binaries using an Authenticode key on an safe and isolated device, distinct from build agents and development machines. Before signature, we scan the binaries for malware.
- We product deterministic builds, so customers that produce builds independently from us and compare the binaries.

## Supported Versions

In case a vulnerability is reported, we would remediate it in all supported versions.

Make sure sure that you are using a supported version. We maintain a list of supported versions on [this page](https://postsharp-web-dev.azurewebsites.net/support/policies/versions).

## Reporting a Vulnerability

To report a vulnerability, post an issue to the [Metalama](https://github.com/metalama/Metalama) repo (without details allowing to exploit the vulnerability) and simultaneously an email to <hello@postsharp.net> with full details.

If you don't get a quick reply, [call us](https://www.postsharp.net/contact).
